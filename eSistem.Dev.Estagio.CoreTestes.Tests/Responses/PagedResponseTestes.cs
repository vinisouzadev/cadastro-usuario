using Bogus;
using eSistem.Dev.Estagio.Core.Models.Account;
using eSistem.Dev.Estagio.Core.Responses;
using FluentAssertions;

namespace eSistem.Dev.Estagio.CoreTestes.Tests.Responses
{
    [Trait("Category", "PagedResponse")]
    public class PagedResponseTestes
    {
        private readonly Faker _faker = new("pt_BR");

        [Fact]
        public void Construtor_DadoOsParametrosDataStatusCodeEMessage_EntaoDevePassarValoresParaBaseCorretamente()
        {
            Usuario usuario = new();
            string expectedUsername = _faker.Person.FirstName;
            usuario.UserName = expectedUsername;
            int expectedStatusCode = _faker.Random.Int(100, 599);
            string expectedMessage = _faker.Lorem.Paragraph();

            PagedResponse<Usuario> pagedResponse = new(usuario, expectedStatusCode,expectedMessage);

            pagedResponse.Data.Should().NotBeNull();
            pagedResponse.Data!.UserName.Should().Be(expectedUsername);
            pagedResponse.StatusCode.Should().Be(expectedStatusCode);
            pagedResponse.Message.Should().Be(expectedMessage);
            
        }
    }
}
