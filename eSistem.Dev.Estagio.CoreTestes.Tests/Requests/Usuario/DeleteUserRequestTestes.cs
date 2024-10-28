using eSistem.Dev.Estagio.Core.Requests.Usuario;
using FluentAssertions;

namespace eSistem.Dev.Estagio.CoreTestes.Tests.Requests.Usuario
{
    [Trait("Category", "DeleteUserRequest")]
    public class DeleteUserRequestTestes
    {
        [Fact]
        public void Construtor_DadoInstanciaSemValores_DeveEntaoSetarValoresDefaultCorretamente()
        {
            DeleteUserRequest request = new();

            request.Id.Should().BeEmpty();
        }
    }
}
