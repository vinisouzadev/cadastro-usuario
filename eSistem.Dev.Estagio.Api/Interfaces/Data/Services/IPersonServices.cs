using eSistem.Dev.Estagio.Api.Models;
using eSistem.Dev.Estagio.Core.Models;

namespace eSistem.Dev.Estagio.Api.Interfaces.Data.Services
{
    public interface IPersonServices
    {
        Task<Person> GetByCpfCnpj(string CpfCpnj);

        Task<Person> CreateAsync(Person pessoa);

        Task<bool> Delete(Person pessoa);
    }
}
