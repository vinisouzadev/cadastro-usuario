using eSistem.Dev.Estagio.Api.Configurations.Builder.Security;

namespace eSistem.Dev.Estagio.Api.Configurations.Builder
{
    public static class SecurityConfiguration
    {
        public static void AddServices(WebApplicationBuilder builder)
        {
            SecurityIdentityConfiguration.AddIdentity(builder);

            SecurityCorsConfiguration.AddCors(builder);
        }

    }
}
