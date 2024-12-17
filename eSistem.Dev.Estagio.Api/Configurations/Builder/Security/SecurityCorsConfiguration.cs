using eSistem.Dev.Estagio.Core;

namespace eSistem.Dev.Estagio.Api.Configurations.Builder.Security
{
    public static class SecurityCorsConfiguration
    {
        public static WebApplicationBuilder AddCors(WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("eSistemCors", options =>
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
