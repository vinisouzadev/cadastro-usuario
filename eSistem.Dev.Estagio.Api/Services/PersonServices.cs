using eSistem.Dev.Estagio.Api.Interfaces.Data.Repository;
using eSistem.Dev.Estagio.Api.Interfaces.Data.Services;
using eSistem.Dev.Estagio.Core.Models;

namespace eSistem.Dev.Estagio.Api.Services
{
    public class PersonServices(IPersonRepository repository) : IPersonServices
    {
        private readonly IPersonRepository _repository = repository;

        public async Task<Person> GetByCpfCnpj(string cpfCpnj)
            => await _repository.GetByCpfCnpj(cpfCpnj);

        public async Task<Person> CreateAsync(Person pessoa)
            => await _repository.Create(pessoa);

        public async Task<bool> Delete(Person pessoa)
         => await _repository.Delete(pessoa);

    }
}
