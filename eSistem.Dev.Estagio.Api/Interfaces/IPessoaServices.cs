using eSistem.Dev.Estagio.Api.Models;
using eSistem.Dev.Estagio.Core.Models;

namespace eSistem.Dev.Estagio.Api.Interfaces
{
    public interface IPessoaService
    {
        PessoaWithUser? GetByCpfCnpj(string CpfCpnj);

        PessoaWithUser Insert(PessoaWithUser pessoa);

        void Delete(PessoaWithUser pessoa);
    }
}
