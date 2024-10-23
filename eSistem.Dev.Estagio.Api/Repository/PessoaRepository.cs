using eSistem.Dev.Estagio.Api.Data;
using eSistem.Dev.Estagio.Api.Interfaces;
using eSistem.Dev.Estagio.Api.Models;
using eSistem.Dev.Estagio.Core.Models;

namespace eSistem.Dev.Estagio.Api.Repository
{
    public class PessoaRepository(AppDbContext context) : IPessoaRepository
    {
        private readonly AppDbContext _context = context;

        public void Delete(PessoaWithUser pessoa)
        {
            _context.Attach(pessoa);
            _context.Pessoas.Remove(pessoa);
            _context.SaveChanges();
        }

        public PessoaWithUser? GetByCpfCnpj(string cpfCnpj)
        {
            PessoaWithUser? pessoa = _context.Pessoas.FirstOrDefault(x => x.CpfCnpj == cpfCnpj) ?? null;

            return pessoa;
        }

        public PessoaWithUser Insert(PessoaWithUser pessoa)
        {
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
            return pessoa;
        }


    }
}
