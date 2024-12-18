using eSistem.Dev.Estagio.Api.Models.Identity;
using eSistem.Dev.Estagio.Api.Services.ServiceResult;

namespace eSistem.Dev.Estagio.Api.Interfaces.Data.Services
{
    public interface IAccountServices
    {
        Task<ServiceResult<Usuario?>> GetByIdPessoa(int idPessoa);

        Task<ServiceResult<Usuario?>> GetByUserNameAsync(string userName);

        Task<ServiceResult<string?>> Delete(Usuario usuario);

        Task<ServiceResult<string>> ValidatePasswordAsync(string password, Usuario user);

        Task<ServiceResult<Usuario?>> CreateAsync(Usuario usuario, string password);

    }
}
