using eSistem.Dev.Estagio.Api.Interfaces;
using eSistem.Dev.Estagio.Api.Models.Identity;
using Microsoft.AspNetCore.Identity;


namespace eSistem.Dev.Estagio.Api.Services
{
    public class AccountServices(IAccountRepository accountRepository, UserManager<Usuario> userManager) : IAccountServices
    {
        private readonly IAccountRepository _accountRepository = accountRepository;

        private readonly UserManager<Usuario> _userManager = userManager;

        public bool Delete(Usuario usuario)
        {
            try
            {
                _accountRepository.Delete(usuario);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Usuario? GetByIdPessoa(int idPessoa)
            => _accountRepository.GetByIdPessoa(idPessoa);

        public Usuario? GetByUserName(string userName)
            => _accountRepository.GetByUserName(userName);

        public async Task<bool> ValidatePasswordAsync(string password, Usuario usuario)
        {
            var isConfirmedPassword = false;

            try
            {
                isConfirmedPassword = await _userManager.CheckPasswordAsync(usuario, password);

                return isConfirmedPassword;
            }
            catch
            {
                return isConfirmedPassword;
            }
        }

        public async Task<bool> Create(Usuario usuario, string password)
            => await _accountRepository.Create(usuario, password);
    }
}
