using eSistem.Dev.Estagio.Api.Interfaces.Data.Repository;
using eSistem.Dev.Estagio.Api.Interfaces.Data.Services;
using eSistem.Dev.Estagio.Api.Models.Identity;
using Microsoft.AspNetCore.Identity;


namespace eSistem.Dev.Estagio.Api.Services
{
    public class AccountServices
        (IAccountRepository accountRepository,
        UserManager<Usuario> userManager,
        IPersonServices personServices,
        IUnityOfWork unityOfWork) : IAccountServices
    {
        private readonly IAccountRepository _accountRepository = accountRepository;

        private readonly UserManager<Usuario> _userManager = userManager;

        private readonly IPersonServices _personServices = personServices;

       ´private readonly IUnityOfWork _unitOfWork = unityOfWork;

        public async Task<Usuario?> GetByIdPessoa(int idPessoa)
            => await _accountRepository.GetByIdPessoa(idPessoa);

        public async Task<Usuario?> GetByUserNameAsync(string userName)
            => await _accountRepository.GetByUserName(userName);

        public async Task<bool> ValidatePasswordAsync(string password, Usuario usuario)
            => await _userManager.CheckPasswordAsync(usuario, password);

        public async Task<bool> Create(Usuario usuario, string password)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                await _personServices.CreateAsync(usuario.Person);

                await _userManager.CreateAsync(usuario, password);

                var commitResult = await _unitOfWork.CommitAsync();

                return commitResult;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
