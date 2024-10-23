using eSistem.Dev.Estagio.Api.Data;
using eSistem.Dev.Estagio.Api.Handlers;
using eSistem.Dev.Estagio.Api.Interfaces;
using eSistem.Dev.Estagio.Api.Models.Identity;
using eSistem.Dev.Estagio.Api.Repository;
using eSistem.Dev.Estagio.Api.Services;
using eSistem.Dev.Estagio.Core;
using eSistem.Dev.Estagio.Core.Handlers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



namespace eSistem.Dev.Estagio.Api.Configurations
{
    public static class BuilderExtensions
    {
        public static WebApplicationBuilder Configurations(this WebApplicationBuilder builder)
        {
            Configuration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

            Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;

            Configuration.FrontendUrl = builder.Configuration.GetValue<string>("FrontendUrl") ?? string.Empty;

            return builder;
        }

        public static WebApplicationBuilder AddEntityFramework(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(Configuration.ConnectionString);
            });

            return builder;
        }

        public static WebApplicationBuilder Security(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddAuthentication(IdentityConstants.ApplicationScheme)
                .AddIdentityCookies();

            builder.Services.AddAuthorization();

            builder.Services
                .AddIdentityCore<Usuario>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddApiEndpoints();

            return builder;
        }

        public static WebApplicationBuilder AddDependencyInjection(this WebApplicationBuilder builder) 
        {
            builder.Services.AddTransient<IPessoaRepository, PessoaRepository>();
            builder.Services.AddTransient<IPessoaService, PessoaServices>();
            builder.Services.AddTransient<IAccountRepository, AccountRepository>();
            builder.Services.AddTransient<IAccountServices, AccountServices>();
            builder.Services.AddTransient<IAccountHandler, AccountHandler>();

            return builder;
        }

        public static WebApplicationBuilder AddCors(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(ApiConfiguration.CorsPolicyName, options =>
                {
                    options.WithOrigins(
                        [
                            Configuration.BackendUrl,
                            Configuration.FrontendUrl
                        ])
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });

            return builder;
        }
    }
}
