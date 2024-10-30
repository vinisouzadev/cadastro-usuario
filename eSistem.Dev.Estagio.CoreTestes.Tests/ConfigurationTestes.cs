using Bogus;
using eSistem.Dev.Estagio.Core;
using FluentAssertions;
using System.Text.RegularExpressions;

namespace eSistem.Dev.Estagio.CoreTestes.Tests
{

    [Trait("Category", "Configuration")]
    public class ConfigurationTestes
    {
        private readonly Faker _faker = new("pt_BR");

        [Fact]
        public void Propriedades_DadoPropriedadesSemAtribuicaoDeValor_EntaoDeveSetarValoresDefaultCorretamente()
        {
            int expectedDefaultStatusCode = Configuration.DefaultStatusCode;
            string expectedBackEndUrl = Configuration.BackendUrl;
            string expectedFrontEndUrl = Configuration.FrontendUrl;
            string expectedConnectionString = Configuration.ConnectionString;
            int expectedDefaultPageSize = Configuration.DefaultPageSize;
            int expectedDefaultCurrentPage = Configuration.DefaultCurrentPage;

            expectedDefaultStatusCode.Should().Be(200);
            expectedBackEndUrl.Should().BeEmpty();
            expectedFrontEndUrl.Should().BeEmpty();
            expectedConnectionString.Should().BeEmpty();
            expectedDefaultPageSize.Should().Be(25);
            expectedDefaultCurrentPage.Should().Be(0);
        }

        [Fact]
        public void CpfCnpjFormatVerify_DadoRegexEParametroCorreto_EntaoDeveCompararFormatacaoCorretamente()
        {
            string correctlyParameterNum = _faker.Random.Int().ToString();

            bool isMatch = Configuration.CpfCnpjFormatVerify(correctlyParameterNum);

            isMatch.Should().BeTrue();
        }

    }
}
