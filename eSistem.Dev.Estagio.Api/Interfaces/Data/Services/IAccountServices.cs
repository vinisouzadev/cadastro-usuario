using eSistem.Dev.Estagio.Api.Models.Identity;

namespace eSistem.Dev.Estagio.Api.Interfaces.Data.Services
{
    public interface IAccountServices
    {
        Task<Usuario?> GetByIdPessoa(int idPessoa);

        Task<Usuario?> GetByUserNameAsync(string userName);

        Task<bool> Delete(Usuario usuario);

        Task<bool> ValidatePasswordAsync(string password, Usuario user);

        Task<bool> Create(Usuario usuario, string password);

    }
}
