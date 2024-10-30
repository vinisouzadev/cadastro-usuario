using Bogus;
using eSistem.Dev.Estagio.Core;
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

        [Fact]
        public void Construtor_DadoQualquerParametro_EntaoDeveSetarPropriedadesDefaultCorretamente()
        {
            Usuario qualquerUsuario = new();
            int qualquerStatusCode = _faker.Random.Int(100, 599);
            int qualquerTotalCount = _faker.Random.Int(0);

            PagedResponse<Usuario> pagedResponse = new(qualquerUsuario, qualquerStatusCode, qualquerTotalCount);

            pagedResponse.CurrentPage = Configuration.DefaultCurrentPage;
            pagedResponse.Message.Should().BeNull();
            pagedResponse.PageSize.Should().Be(Configuration.DefaultPageSize);
        }
    }
}
