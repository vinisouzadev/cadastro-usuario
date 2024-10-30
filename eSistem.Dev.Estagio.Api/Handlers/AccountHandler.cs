using eSistem.Dev.Estagio.Api.Interfaces;
using eSistem.Dev.Estagio.Api.Models;
using eSistem.Dev.Estagio.Core;
using eSistem.Dev.Estagio.Core.Enums;
using eSistem.Dev.Estagio.Core.Handlers;
using eSistem.Dev.Estagio.Core.Requests.Account;
using eSistem.Dev.Estagio.Core.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using eSistem.Dev.Estagio.Core.Requests.Usuario;

namespace eSistem.Dev.Estagio.Api.Handlers
{
    public class AccountHandler
        (IPessoaService pessoaServices,
        SignInManager<Models.Identity.Usuario> signInManager,
        UserManager<Models.Identity.Usuario> userManager,
        IAccountServices accountService) : IAccountHandler
    {
        private readonly IPessoaService _pessoaServices = pessoaServices;

        private readonly SignInManager<Models.Identity.Usuario> _signInManager = signInManager;

        private readonly UserManager<Models.Identity.Usuario> _userManager = userManager;

        private readonly IAccountServices _accountService = accountService;


        public async Task<Response<string?>> DeleteUserAsync(DeleteUserRequest request)
        {
            if (GenericServices.IsNullOrEmptyOrContainsSpace(request.Id, request.UserId))
                return new Response<string?>(string.Empty, 404, "Usuário está nulo");

            var user = await _userManager.FindByNameAsync(request.Id);



            if (user is null)
                return new Response<string?>(string.Empty, 404, "Usuário não encontrado");

            try
            {
                var result = await _userManager.DeleteAsync(user);

                if (!result.Succeeded)
                    return new Response<string?>(string.Empty, 400, "Não foi possível deletar o usuário");
            }
            catch
            {
                return new Response<string?>(string.Empty, 500, "Não foi possível deletar o usuário");
            }

            return new Response<string?>(string.Empty, 204, string.Empty);
        }

        public async Task<Response<string?>> EditPasswordAsync(EditPasswordRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserId);

            if (user is null)
                return new Response<string?>(string.Empty, 404, "Não foi possível encontrar o usuário");

            if (GenericServices.IsNullOrEmptyOrContainsSpace(request.CurrentPassword, request.Password))
                return new Response<string?>(string.Empty, 400, "Senha vazia.");

            try
            {
                var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.Password);

                if (!result.Succeeded)
                    return new Response<string?>(null, 400, "Não foi possível atualizar a senha");
            }
            catch
            {
                return new Response<string?>(string.Empty, 500, "Não foi possível atualizar a senha");
            }

            return new Response<string?>(string.Empty, 204, "Senha atualizada com sucesso!");

        }

        public async Task<Response<Core.Models.Account.Usuario?>> EditUserAsync(EditUserRequest request)
        {
            if (GenericServices.IsNullOrEmptyOrContainsSpace(request.Id, request.UserId))
                return new Response<Core.Models.Account.Usuario?>(null, 404, "Não foi possível identificar o usuário");
            
            bool emptyUserName = GenericServices.IsNullOrEmptyOrContainsSpace(request.UserName);

            if (emptyUserName && request.UserName != null && request.UserName.Contains(" "))
                return new Response<Core.Models.Account.Usuario?>(null, 400, "O nome de usuário não pode ser nulo");

            bool emptyNomeRazaoSocial = string.IsNullOrEmpty(request.NomeRazaoSocial);

            if (emptyNomeRazaoSocial && emptyUserName)
                return new Response<Core.Models.Account.Usuario?>(null, 404, "O input veio nulo ou vazio");

            Core.Models.Account.Usuario? usuario = null;
            try
            {
                var user = _accountService.GetByUserName(request.Id);

                if (user is null)
                    return new Response<Core.Models.Account.Usuario?>(null, 404, "Não foi encontrado este usuário");



                if (!emptyUserName && request.UserName != user.UserName)
                {
                    var userExist = await _userManager.FindByNameAsync(request.UserName);

                    if (userExist is not null)
                        return new Response<Core.Models.Account.Usuario?>(null, 400, "Este nome de usuário já está sendo utilizado");

                    user.UserName = request.UserName;
                }

                if (!emptyNomeRazaoSocial && request.NomeRazaoSocial != user.Pessoa.NomeRazaoSocial)
                {
                    user.Pessoa.NomeRazaoSocial = request.NomeRazaoSocial;

                    var result = await _userManager.UpdateAsync(user);


                    if (!result.Succeeded)
                        return new Response<Core.Models.Account.Usuario?>(null, 500, "Não foi possível atualizar este usuário");
                }

                Dictionary<string, string> roles = [];

                var rolesList = await _userManager.GetRolesAsync(user);

                roles.Add(ClaimTypes.Role, rolesList.FirstOrDefault() ?? string.Empty);

                usuario = new()
                {
                    UserName = user.UserName,
                    Pessoa = user.Pessoa,
                    Claims = roles
                };

                return new Response<Core.Models.Account.Usuario?>(usuario, 200, "");
            }
            catch
            {
                return new Response<Core.Models.Account.Usuario?>(null, 500, "Não foi possível atualizar este usuário");
            }
        }

        public async Task<PagedResponse<List<Core.Models.Account.Usuario?>>> GetAllUsersAsync(GetAllUsersRequest request)
        {
            try
            {
                List<Core.Models.Account.Usuario?> usuarios = [];
                var users = await _userManager.Users.Include(x => x.Pessoa).ToListAsync();



                foreach (var user in users)
                {
                    Dictionary<string, string> userRoles = [];
                    var roles = await _userManager.GetRolesAsync(user);

                    userRoles.Add(ClaimTypes.Role, roles.FirstOrDefault() ?? string.Empty);
                    usuarios.Add(new Core.Models.Account.Usuario
                    {
                        UserName = user.UserName,
                        Pessoa = user.Pessoa,
                        Claims = userRoles
                    });


                }



                return new PagedResponse<List<Core.Models.Account.Usuario?>>(usuarios, 200, "Usuários retornados com sucesso!");
            }
            catch
            {
                return new PagedResponse<List<Core.Models.Account.Usuario?>>([], 500, "Falha ao retornar usuarios");
            }

        }

        /// <summary>
        /// Busca as informações do usuário através do seu ClaimsPrincipal no Identity. Se for vazio, retorna nulo. Em seguida,
        /// confirma se existe realmente um usuário cadastrado no banco com este UserName. Caso haja, passa as informações desse
        /// ClaimsPrincipal para o Usuario personalizado que será chamado no front-end. Caso haja claims nesse user, passa para
        /// o usuarioEncontrado.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<Response<Core.Models.Account.Usuario?>> GetUserInfoAsync(GetUserInfoRequest request)
        {

            var userName = request.UserId;

            if (string.IsNullOrEmpty(userName))
                return Task.FromResult(new Response<Core.Models.Account.Usuario?>(null, 404, "Não foi possível encontrar este usuário"));

            var usuario = _accountService.GetByUserName(userName);

            if (usuario is null)
                return Task.FromResult(new Response<Core.Models.Account.Usuario?>(null, 404, "Não foi possível encontrar este usuário"));

            Core.Models.Account.Usuario? usuarioEncontrado = new()
            {
                UserName = usuario.UserName!,
                Pessoa = usuario.Pessoa
            };

            if (request.Claims.Any())
            {
                foreach (var claim in request.Claims)
                {
                    var claimsUser = usuarioEncontrado.Claims.Where(x => x.Key == claim.Type);
                    if (claimsUser is null)
                        usuarioEncontrado.Claims.Add(claim.Type, claim.Value);
                }
            }

            return Task.FromResult(new Response<Core.Models.Account.Usuario?>(usuarioEncontrado));
        }

        /// <summary>
        /// Endpoint de login do usuário. Faz validações referentes a formatação e chama SignInManager para realizar 
        /// o login através de PasswordSignInAsync() passando request.UserName e request.Password como parâmetro.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Uma Response contendo string vazia como TData, StatusCode 
        /// referente a situação e uma Message personalizada para a situação</returns>
        public async Task<Response<string?>> LoginAsync(LoginRequest request)
        {
            if (GenericServices.IsNullOrEmptyOrContainsSpace(request.UserName, request.Password))
                return new Response<string?>(string.Empty, 400, "Este campo não pode estar vazio ou conter espaços");
            var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, true);

            if (!result.Succeeded)
                return new Response<string?>(string.Empty, 400, "Usuário ou senha incorretas");

            return new Response<string?>(string.Empty, 200, "Login realizado com sucesso!");
        }

        /// <summary>
        /// Realiza o logout do usuário através do SignInManager.
        /// </summary>
        /// <returns></returns>
        public async Task<Response<string?>> LogoutAsync()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return new Response<string?>(string.Empty, 200, "Logout realizado com sucesso");
            }
            catch
            {
                return new Response<string?>(string.Empty, 500, "Não foi possível realizar o logout");
            }
        }

        /// <summary>
        /// Realiza o registro do usuário. Recebe os dados de cadastro do usuário e também
        /// um cadastro de pessoa. Verifica se já existe essa pessoa cadastrada via documento
        /// (CPF ou CNPJ) e caso não exista a cadastra no banco. Caso exista uma pessoa cadastrada, valida
        /// se essa pessoa está associada a um usuário e se estiver gera um response com status code 400.
        /// Caso não exista, realiza validações de formatação, adiciona o usuário ao banco e adiciona
        /// suas roles caso precise. Caso haja falha na adição de roles, ele deleta o usuário automaticamente.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<string?>> RegisterAsync(RegisterRequest request)
        {
            //Validar o request.


            PessoaWithUser? pessoa = _pessoaServices.GetByCpfCnpj(request.CpfCnpj);

            Models.Identity.Usuario user = new();

            if (pessoa is not null)
            {
                if (_accountService.GetByIdPessoa(pessoa.Id) is not null)
                    return new Response<string?>(string.Empty, 400, "Já existe um usuário vinculado a esta pessoa");
            }
            switch (request.Tipo)
            {
                case ETipo.Fisico:
                    {
                        if (request.CpfCnpj.Length != 11)
                            return new Response<string?>(string.Empty, 400, "O CPF deve ter exatamente 11 caracteres");
                        else if (!Configuration.CpfCnpjFormatVerify(request.CpfCnpj))
                            return new Response<string?>(string.Empty, 400, "Digite apenas números");
                    }
                    break;
                case ETipo.Juridico:
                    {
                        if (request.CpfCnpj.Length != 14)
                            return new Response<string?>(string.Empty, 400, "O CNPJ deve ter exatamente 14 caracteres");
                        else if (!Configuration.CpfCnpjFormatVerify(request.CpfCnpj))
                            return new Response<string?>(string.Empty, 400, "Digite apenas números");
                    }
                    break;
                default:
                    return new Response<string?>(string.Empty, 400, "O tipo deve ser apenas físico ou jurídico.");
            }

            if (pessoa is null)
            {
                pessoa = new PessoaWithUser
                {
                    NomeRazaoSocial = request.NomeRazaoSocial,
                    CpfCnpj = request.CpfCnpj,
                    Tipo = request.Tipo
                };

            }


            if (GenericServices.IsNullOrEmptyOrContainsSpace(request.UserName))
                return new Response<string?>(string.Empty, 400, "Não são permitidos espaços no nome de usuário");
            else if (GenericServices.IsNullOrEmptyOrContainsSpace(request.Password))
                return new Response<string?>(string.Empty, 400, "Não são permitidos espaços na senha");

            bool userNameExists = _accountService.GetByUserName(request.UserName) is null;

            if (!userNameExists)
                return new Response<string?>(string.Empty, 400, "Este username já existe.");

            user.Pessoa = pessoa;
            user.Pessoa.User = user;
            user.IdPessoa = pessoa.Id;
            user.UserName = request.UserName;

            var result = await _accountService.Create(user, request.Password);

            if (!result)
                return new Response<string?>("Falha ao criar a conta", 400, "Falha ao criar a conta");

            if (await _userManager.Users.CountAsync() == 1)
            {
                if (!await AddRoles(user.UserName))
                {
                    _accountService.Delete(user);
                    return new Response<string?>(string.Empty, 500, "Falha ao criar a conta");
                }
            }

            return new Response<string?>("sucesso", 201, "Conta criada com sucesso!");


        }

        /// <summary>
        /// Busca por usuário e se não econtrar retorna false. Caso encontre, gera uma role de "Admin"
        /// para o usuário
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        private async Task<bool> AddRoles(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user is null)
                return false;

            await _userManager.AddToRoleAsync(user!, "Admin");

            return true;
        }

    }
}
