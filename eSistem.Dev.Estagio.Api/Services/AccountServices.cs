using eSistem.Dev.Estagio.Api.Interfaces.Data.Repository;
using eSistem.Dev.Estagio.Api.Interfaces.Data.Services;
using eSistem.Dev.Estagio.Api.Interfaces.IServiceResult;
using eSistem.Dev.Estagio.Api.Models.Identity;
using eSistem.Dev.Estagio.Api.Services.ServiceResult;
using Microsoft.AspNetCore.Identity;
using System.Collections;


namespace eSistem.Dev.Estagio.Api.Services
{
    public class AccountServices
        (IAccountRepository accountRepository,
        UserManager<Usuario> userManager,
        IPersonServices personServices,
        IUnityOfWork unityOfWork,
        IServiceResultManager serviceResultManager) : IAccountServices
    {
        private readonly IAccountRepository _accountRepository = accountRepository;

        private readonly UserManager<Usuario> _userManager = userManager;

        private readonly IPersonServices _personServices = personServices;

        private readonly IUnityOfWork _unitOfWork = unityOfWork;

        private readonly IServiceResultManager _serviceResultManager = serviceResultManager;


        public async Task<ServiceResult<Usuario?>> GetByIdPessoa(int idPessoa)
        {
            var user = await _accountRepository.GetByIdPessoa(idPessoa);

            return GenerateGetUserServiceResult(user);
        }

        public async Task<ServiceResult<Usuario?>> GetByUserNameAsync(string userName)
        {
            var user = await _accountRepository.GetByUserName(userName);

            return GenerateGetUserServiceResult(user);
        }

        public async Task<ServiceResult<string>> ValidatePasswordAsync(string password, Usuario usuario)
        {
            var result = await _userManager.CheckPasswordAsync(usuario, password);
            var failureServiceResult = _serviceResultManager.VoidServiceResult.Failure();
            failureServiceResult.AddError("A senha não confere");
            return result
                ? _serviceResultManager.VoidServiceResult.Success(string.Empty)
                : failureServiceResult;
        }

        public async Task<ServiceResult<Usuario?>> CreateAsync(Usuario usuario, string password)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                await _personServices.CreateAsync(usuario.Person);

                var result = await _userManager.CreateAsync(usuario, password);

                if (!result.Succeeded)
                {
                    var serviceResult = _serviceResultManager.UserServiceResult.Failure();
                    serviceResult.AddErrorsList(result.Errors);

                    return serviceResult;
                }


                await _unitOfWork.CommitAsync();

                return _serviceResultManager.UserServiceResult.Success(usuario);

            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                var failureServiceResult = _serviceResultManager.UserServiceResult.Failure();
                failureServiceResult.AddError(ex.Message);
                return failureServiceResult;
            }
        }

        public Task<ServiceResult<string>> Delete(Usuario usuario)
        {
            throw new NotImplementedException();
        }


        #region Private methods

        private static bool IsUserNull(Usuario? usuario)
            => usuario is null;

        private ServiceResult<Usuario?> GenerateGetUserServiceResult(Usuario? user)
        {
            if (IsUserNull(user))
            {
                var failureServiceResult = _serviceResultManager.UserServiceResult.Failure();
                failureServiceResult.AddError("Nenhum usuário foi encontrado");
                return failureServiceResult;
            }
            return _serviceResultManager.UserServiceResult.Success(user);
        }

        #endregion

    }
}
