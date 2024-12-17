using eSistem.Dev.Estagio.Api.Configurations.Builder;

namespace eSistem.Dev.Estagio.Api.Configurations
{
    public static class BuilderConfigurations
    {
        public static WebApplicationBuilder AddApiConfigurations(this WebApplicationBuilder builder)
        {   
            AppSettingsValuesConfiguration.LoadConfigurationValues(builder);

            EntityFrameworkConfiguration.AddEntityFramework(builder);

            SecurityConfiguration.AddServices(builder);

            DependencyInjectionConfiguration.AddDependencies(builder);

            return builder;
        }
    }
}
