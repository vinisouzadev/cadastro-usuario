using eSistem.Dev.Estagio.Api.Models.Identity;

namespace eSistem.Dev.Estagio.Api.Interfaces
{
    public interface IAccountRepository
    {
        Usuario? GetByIdPessoa(int idPessoa);

        Usuario? GetByUserName(string userName);

        void Delete(Usuario usuario);

        Task<bool> Create(Usuario usuario, string password);
    }
}
