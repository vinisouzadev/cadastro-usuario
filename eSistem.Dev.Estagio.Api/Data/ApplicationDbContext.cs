using eSistem.Dev.Estagio.Api.Models;
using eSistem.Dev.Estagio.Api.Models.Identity;
using eSistem.Dev.Estagio.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace eSistem.Dev.Estagio.Api.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<PersonWithUser> People { get; set; }

        public DbSet<Usuario> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {   
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
