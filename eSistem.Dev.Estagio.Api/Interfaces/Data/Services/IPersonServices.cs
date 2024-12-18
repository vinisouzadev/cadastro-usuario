using eSistem.Dev.Estagio.Api.Models;
using eSistem.Dev.Estagio.Core.Models;

namespace eSistem.Dev.Estagio.Api.Interfaces.Data.Services
{
    public interface IPersonServices
    {
        Task<PersonWithUser?> GetByCpfCnpj(string CpfCpnj);

        Task<PersonWithUser?> CreateAsync(PersonWithUser pessoa);

        Task<bool> Delete(PersonWithUser pessoa);
    }
}
