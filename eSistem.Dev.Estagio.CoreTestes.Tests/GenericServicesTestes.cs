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
        public void IsNullOrEmptyOrContainsSpace_DadoStringPreenchidaSemEspacoComoParametro_EntaoDeveRetornarFalse()
        {
            string correctlStringParameter = _faker.Person.UserName;
            
            bool isNullOrConstainsSpace = GenericServices.IsNullOrEmptyOrContainsSpace(correctlStringParameter);

            isNullOrConstainsSpace.Should().BeFalse();
        }
    }
}
