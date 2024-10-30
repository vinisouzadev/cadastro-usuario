using Bogus;
using eSistem.Dev.Estagio.Core;
using FluentAssertions;

namespace eSistem.Dev.Estagio.CoreTestes.Tests
{
    [Trait("Category", "GenericServices")]
    public class GenericServicesTestes
    {
        private readonly Faker _faker = new("pt_BR");

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

        [Fact]
        public void IsNullOrEmptyOrContainsSpace_DadoDuasStringsPreenchidasSemEspacoComoParametro_EntaoDeveRetornarFalse()
        {
            string firstStringParameter = _faker.Person.FirstName;
            string secondStringParameter = _faker.Person.LastName;

            bool isNullOrEmptyOrContainsSpace = GenericServices.IsNullOrEmptyOrContainsSpace(firstStringParameter, secondStringParameter);

            isNullOrEmptyOrContainsSpace.Should().BeFalse();
        }

        [Fact]
        public void IsNullOrEmptyOrContainsSpace_DadoPrimeiraStringNulaESegundaStringPreenchida_EntaoDeveRetornarTrue()
        {
            string? stringNull = null;
            string stringPreenchida = _faker.Person.FirstName;

            bool IsNullOrEmptyOrContainsSpace = GenericServices.IsNullOrEmptyOrContainsSpace(stringNull, stringPreenchida);

            IsNullOrEmptyOrContainsSpace.Should().BeTrue();
        }

        [Fact]
        public void IsNullOrEmptyOrContainsSpace_DadoPrimeiraStringPreenchidaESegundaStringNula_EntaoDeveRetornarTrue()
        {
            string stringPreenchida = _faker.Person.FirstName;
            string? stringNull = null;
            bool IsNullOrEmptyOrContainsSpace = GenericServices.IsNullOrEmptyOrContainsSpace(stringPreenchida, stringNull);

            IsNullOrEmptyOrContainsSpace.Should().BeTrue();
        }

    }
}
