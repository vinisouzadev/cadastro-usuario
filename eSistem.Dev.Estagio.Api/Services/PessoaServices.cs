using eSistem.Dev.Estagio.Api.Interfaces;
using eSistem.Dev.Estagio.Api.Models;
using eSistem.Dev.Estagio.Core.Models;

namespace eSistem.Dev.Estagio.Api.Services
{
    public class PessoaServices(IPessoaRepository repository) : IPessoaService
    {
        private readonly IPessoaRepository _repository = repository;

        public PessoaWithUser? GetByCpfCnpj(string cpfCpnj)
            => _repository.GetByCpfCnpj(cpfCpnj);

        public PessoaWithUser Insert(PessoaWithUser pessoa)
            => _repository.Insert(pessoa);

        public void Delete(PessoaWithUser pessoa)
        {
            _repository.Delete(pessoa);
        }

    }
}
