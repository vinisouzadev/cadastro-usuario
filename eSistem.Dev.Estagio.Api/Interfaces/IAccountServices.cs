using eSistem.Dev.Estagio.Api.Models.Identity;

namespace eSistem.Dev.Estagio.Api.Interfaces
{
    public interface IAccountServices
    {
        Usuario? GetByIdPessoa(int idPessoa); 

        Usuario? GetByUserName(string userName);

        bool Delete(Usuario usuario);

        Task<bool> ValidatePasswordAsync(string password, Usuario user);

        Task<bool> Create(Usuario usuario, string password);

    }
}
