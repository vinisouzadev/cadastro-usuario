using eSistem.Dev.Estagio.Api.Models;
using eSistem.Dev.Estagio.Core.Models;

namespace eSistem.Dev.Estagio.Api.Interfaces.Data.Repository
{
    public interface IPersonRepository
    {
        Task<PersonWithUser?> GetByCpfCnpjAsync(string cpfCnpj);

        Task<PersonWithUser> CreateAsync(PersonWithUser person);

        Task<bool> DeleteAsync(PersonWithUser person);

    }
}
