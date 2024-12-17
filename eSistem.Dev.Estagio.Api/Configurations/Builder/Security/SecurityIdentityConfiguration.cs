using eSistem.Dev.Estagio.Api.Data;
using eSistem.Dev.Estagio.Api.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace eSistem.Dev.Estagio.Api.Configurations.Builder.Security
{
    public static class SecurityIdentityConfiguration
    {
        public static WebApplicationBuilder AddIdentity(WebApplicationBuilder builder)
        {
            builder.Services
                .AddAuthentication(IdentityConstants.ApplicationScheme)
                .AddIdentityCookies();

            builder.Services.AddAuthorization();

            builder.Services
                .AddIdentityCore<Usuario>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddApiEndpoints();

            return builder;
        }
    }
}
}
