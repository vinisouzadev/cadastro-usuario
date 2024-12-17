using eSistem.Dev.Estagio.Api.AutoMapper;
using eSistem.Dev.Estagio.Api.Handlers;
using eSistem.Dev.Estagio.Api.Interfaces.Data.Repository;
using eSistem.Dev.Estagio.Api.Interfaces.Data.Services;
using eSistem.Dev.Estagio.Api.Repository;
using eSistem.Dev.Estagio.Api.Services;
using eSistem.Dev.Estagio.Core.Handlers;

namespace eSistem.Dev.Estagio.Api.Configurations.Builder
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencies(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IPersonRepository, PessoaRepository>();
            builder.Services.AddTransient<IPersonServices, PersonServices>();
            builder.Services.AddTransient<IAccountRepository, AccountRepository>();
            builder.Services.AddTransient<IAccountServices, AccountServices>();
            builder.Services.AddTransient<IAccountHandler, AccountHandler>();
            builder.Services.AddAutoMapper(typeof(PersonCloneProfile));

        }
    }
}
