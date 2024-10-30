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

        #region IsNullOrEmptyOrContainsSpace com 2 strings como parâmetro

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
        public void IsNullOrEmptyOrContainsSpace_DadoDuasStringsVaziasOuNulas_EntaoDeveRetornarTrue(string? stringNullOrEmpty)
        {
            bool isNullOrEmptyOrContainsSpace = GenericServices.IsNullOrEmptyOrContainsSpace(stringNullOrEmpty);

            isNullOrEmptyOrContainsSpace.Should().BeTrue();
        }

        [Fact]
        public void IsNullOrEmptyOrContainsSpace_DadoPrimeiraStringPreenchidaESegundaStringComEspaco_EntaoDeveRetornarTrue()
        {
            string stringPreenchida = _faker.Person.FirstName;
            string stringComEspaco = _faker.Lorem.Paragraph();

            bool containsSpace = GenericServices.IsNullOrEmptyOrContainsSpace(stringPreenchida, stringComEspaco);

            containsSpace.Should().BeTrue();
        }

        [Fact]
        public void IsNullOrEmptyOrContainsSpace_DadoPrimeiraStringComEspacoESegundaStringPreenchida_EntaoDeveRetornarTrue()
        {
            string stringComEspaco = _faker.Lorem.Paragraph();
            string stringPreenchida = _faker.Person.FirstName;
            
            bool containsSpace = GenericServices.IsNullOrEmptyOrContainsSpace(stringComEspaco, stringPreenchida);

            containsSpace.Should().BeTrue();
        }

        [Fact]
        public void IsNullOrEmptyOrContainsSpace_DadoAmbasStringsContenhamEspaco_EntaoDeveRetornarFalse()
        {
            string firstStringComEspaco = _faker.Lorem.Paragraph();
            string secondStringComEspaco = _faker.Lorem.Paragraph();

            bool containsSpace = GenericServices.IsNullOrEmptyOrContainsSpace(firstStringComEspaco, secondStringComEspaco);

            containsSpace.Should().BeTrue();
        }

        #endregion

    }
}
