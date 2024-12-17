using eSistem.Dev.Estagio.Api.Models.Identity;

namespace eSistem.Dev.Estagio.Api.Interfaces.Data.Repository
{
    public interface IAccountRepository
    {
        Task<Usuario?> GetByIdPessoa(int idPessoa);

        Task<Usuario?> GetByUserName(string userName);
    }
}
