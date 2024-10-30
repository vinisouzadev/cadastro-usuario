using eSistem.Dev.Estagio.Api.Configurations;
using FluentAssertions;

namespace eSistem.Dev.Estagio.ApiTestes.Tests.Configurations
{
    [Trait("Category", "ApiConfigurations")]
    public class ApiConfigurationsTestes
    {
        [Fact]
        public void CorsPolicyName_DadoUmaVariavelReferenciandoAConstante_DeveSetarValorCorreto()
        {
            string expectedString = "eSistemCors";

            ApiConfiguration.CorsPolicyName.Should().Be(expectedString);
        }
    }
}
