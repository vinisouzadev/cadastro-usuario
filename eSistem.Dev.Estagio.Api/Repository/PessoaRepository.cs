using eSistem.Dev.Estagio.Api.Data;
using eSistem.Dev.Estagio.Api.Interfaces.Data.Repository;
using eSistem.Dev.Estagio.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace eSistem.Dev.Estagio.Api.Repository
{
    public class PessoaRepository(ApplicationDbContext context) : IPersonRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<bool> DeleteAsync(PersonWithUser pessoa)
        {
            _context.Attach(pessoa);
            _context.People.Remove(pessoa);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<PersonWithUser?> GetByCpfCnpjAsync(string cpfCnpj)
            => await _context.People.FirstOrDefaultAsync(x => x.CpfCnpj == cpfCnpj);

        public async Task<PersonWithUser> CreateAsync(PersonWithUser pessoa)
        {   
            var newPerson = new PersonWithUser()
            {
                Ativo = pessoa.Ativo,
                Cadastro = pessoa.Cadastro,
                CpfCnpj = pessoa.CpfCnpj,
                Id = pessoa.Id,
                NomeRazaoSocial = pessoa.NomeRazaoSocial,
                Tipo = pessoa.Tipo,
                Usuario = pessoa.Usuario
            };

            await _context.People.AddAsync(newPerson);
            await _context.SaveChangesAsync();
            return newPerson;
        }
    }
}
