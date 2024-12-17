using eSistem.Dev.Estagio.Api.Data;
using eSistem.Dev.Estagio.Api.Handlers;
using eSistem.Dev.Estagio.Api.Models.Identity;
using eSistem.Dev.Estagio.Api.Repository;
using eSistem.Dev.Estagio.Api.Services;
using eSistem.Dev.Estagio.Core.Handlers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eSistem.Dev.Estagio.ApiTestes.Tests.Configurations
{
    [Trait("Category", "AccountHandler")]
    public class AccountHandlerTestes
    {
        private readonly AccountHandler _handler;
        private readonly SignInManager<Usuario> _signInManager;

        public AccountHandlerTestes(IAccountHandler handler)
        {
            var dbContextBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            dbContextBuilder.UseInMemoryDatabase("ApiTeste");
            ApplicationDbContext dbContext = new(dbContextBuilder.Options);

            SignInManager<Usuario> signInManager = new(null, null, null, null, null, null, null);

            PessoaRepository pessoaRepository = new(dbContext);
            PersonServices pessoaServices = new(pessoaRepository);
            AccountHandler _handler = new(pessoaServices,);
        }

        [Fact]
        public void 
    }
}
