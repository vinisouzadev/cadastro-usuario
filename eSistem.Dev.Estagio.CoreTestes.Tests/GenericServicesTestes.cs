using Bogus;
using eSistem.Dev.Estagio.Core;
using FluentAssertions;

namespace eSistem.Dev.Estagio.CoreTestes.Tests
{
    [Trait("Category", "GenericServices")]
    public class GenericServicesTestes
    {
        private readonly Faker _faker = new("pt_BR");

        #region IsNullOrEmptyOrContainsSpace com 1 string como parâmetro

        [Fact]
        public void IsNullOrEmptyOrContainsSpace_DadoUmaStringPreenchidaSemEspacoComoParametro_EntaoDeveRetornarFalse()
        {
            string correctlyStringParameter = _faker.Person.UserName;

            bool isNullOrConstainsSpace = GenericServices.IsNullOrEmptyOrContainsSpace(correctlyStringParameter);

            isNullOrConstainsSpace.Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void IsNullOrEmptyOrContainsSpace_DadoUmaStringNulaOuVazia_EntaoDeveRetornarTrue(string? stringParameter)
        {
            bool isNullOrContainsSpace = GenericServices.IsNullOrEmptyOrContainsSpace(stringParameter);

            isNullOrContainsSpace.Should().BeTrue();
        }

        [Fact]
        public void IsNullOrEmptyOrContainsSpace_DadoUmaStringComEspaco_EntaoDeveRetornarTrue()
        {
            string stringWithSpace = _faker.Lorem.Paragraph();

            bool containsSpace = GenericServices.IsNullOrEmptyOrContainsSpace(stringWithSpace);

            containsSpace.Should().BeTrue();
        }

        #endregion


        [Fact]
        public void IsNullOrEmptyOrContainsSpace_DadoDuasStringsPreenchidasSemEspacoComoParametro_EntaoDeveRetornarFalse()
        {
            string firstStringParameter = _faker.Person.FirstName;
            string secondStringParameter = _faker.Person.LastName;

            bool isNullOrEmptyOrContainsSpace = GenericServices.IsNullOrEmptyOrContainsSpace(firstStringParameter, secondStringParameter);

            isNullOrEmptyOrContainsSpace.Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void IsNullOrEmptyOrContainsSpace_DadoPrimeiraStringNulaOuVaziaESegundaStringPreenchida_EntaoDeveRetornarTrue(string? stringNullOrEmpty)
        {
            string stringPreenchida = _faker.Person.FirstName;

            bool IsNullOrEmptyOrContainsSpace = GenericServices.IsNullOrEmptyOrContainsSpace(stringNullOrEmpty, stringPreenchida);

            IsNullOrEmptyOrContainsSpace.Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void IsNullOrEmptyOrContainsSpace_DadoPrimeiraStringPreenchidaESegundaStringNulaOuVazia_EntaoDeveRetornarTrue(string? stringNullOrEmpty)
        {
            string stringPreenchida = _faker.Person.FirstName;

            bool IsNullOrEmptyOrContainsSpace = GenericServices.IsNullOrEmptyOrContainsSpace(stringPreenchida, stringNullOrEmpty);

            IsNullOrEmptyOrContainsSpace.Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void IsNullOrEmptyOrContainsSpace_DadoDuasStringsVaziasOuNulas_EntaoDeveRetornarTrue(string stringNullOrEmpty)
        {
            bool IsNullOrEmptyOrContainsSpace = GenericServices.IsNullOrEmptyOrContainsSpace(stringNullOrEmpty);

            IsNullOrEmptyOrContainsSpace.Should().BeTrue();
        }

    }
}
