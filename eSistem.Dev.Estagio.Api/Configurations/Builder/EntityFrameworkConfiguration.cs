using eSistem.Dev.Estagio.Api.Data;
using eSistem.Dev.Estagio.Core;
using Microsoft.EntityFrameworkCore;

namespace eSistem.Dev.Estagio.Api.Configurations.Builder
{
    public static class EntityFrameworkConfiguration
    {
        public static void AddEntityFramework(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(Configuration.ConnectionString);
            });
        }
    }
}
