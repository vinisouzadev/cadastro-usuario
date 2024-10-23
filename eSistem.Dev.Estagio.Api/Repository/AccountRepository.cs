using eSistem.Dev.Estagio.Api.Data;
using eSistem.Dev.Estagio.Api.Interfaces;
using eSistem.Dev.Estagio.Api.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eSistem.Dev.Estagio.Api.Repository
{
    public class AccountRepository(AppDbContext context, UserManager<Usuario> userManager) : IAccountRepository
    {
        private readonly AppDbContext _context = context;

        private readonly UserManager<Usuario> _userManager = userManager;

        public Usuario? GetByIdPessoa(int idPessoa)
            => _context.Usuarios.FirstOrDefault(x => x.IdPessoa == idPessoa);

        public Usuario? GetByUserName(string userName)
            => _context.Usuarios.Include(x => x.Pessoa).FirstOrDefault(x => x.UserName == userName);

        public void Delete(Usuario usuario)
        {
            _context.Attach(usuario);
            _context.Entry(usuario).State = EntityState.Deleted;
            _context.SaveChanges();
            
        }

        public async Task<bool> Create(Usuario usuario, string password)
        {
            var pessoa = usuario.Pessoa;

            _context.Pessoas.Add(pessoa);
            var result = await _userManager.CreateAsync(usuario, password);

            if (result.Succeeded)
            {
                try
                {
                   await _context.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
                
            return false;
        }
    }
}
