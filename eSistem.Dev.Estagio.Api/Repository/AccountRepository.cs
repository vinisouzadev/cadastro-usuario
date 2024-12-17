using eSistem.Dev.Estagio.Api.Data;
using eSistem.Dev.Estagio.Api.Interfaces.Data.Repository;
using eSistem.Dev.Estagio.Api.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace eSistem.Dev.Estagio.Api.Repository
{
    public class AccountRepository(ApplicationDbContext context) : IAccountRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Usuario?> GetByIdPessoa(int idPessoa)
            => await _context.Users.FirstOrDefaultAsync(x => x.IdPerson == idPessoa);

        public async Task<Usuario?> GetByUserName(string userName)
            => await _context.Users.Include(x => x.Person).FirstOrDefaultAsync(x => x.UserName == userName);
    
    }
}
