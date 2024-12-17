using eSistem.Dev.Estagio.Core;

namespace eSistem.Dev.Estagio.Api.Configurations.Builder
{
    public static class AppSettingsValuesConfiguration
    {
        public static void LoadConfigurationValues(WebApplicationBuilder builder)
        {
            Configuration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

            Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;

            Configuration.FrontendUrl = builder.Configuration.GetValue<string>("FrontendUrl") ?? string.Empty;

        }
    }
}
