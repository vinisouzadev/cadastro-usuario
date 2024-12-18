using eSistem.Dev.Estagio.Api.Interfaces.Data.Repository;
using eSistem.Dev.Estagio.Api.Interfaces.Data.Services;
using eSistem.Dev.Estagio.Api.Models;
using eSistem.Dev.Estagio.Core.Models;

namespace eSistem.Dev.Estagio.Api.Services
{
    public class PersonServices(IPersonRepository repository) : IPersonServices
    {
        private readonly IPersonRepository _repository = repository;

        public async Task<PersonWithUser?> GetByCpfCnpj(string cpfCpnj)
            => await _repository.GetByCpfCnpjAsync(cpfCpnj) ?? null;

        public async Task<PersonWithUser?> CreateAsync(PersonWithUser pessoa)
            => await _repository.CreateAsync(pessoa);

        public async Task<bool> Delete(PersonWithUser pessoa)
         => await _repository.DeleteAsync(pessoa);

    }
}
