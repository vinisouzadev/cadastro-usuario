using eSistem.Dev.Estagio.Core.Requests.Usuario;
using FluentAssertions;

namespace eSistem.Dev.Estagio.CoreTestes.Tests.Requests.Usuario
{
    [Trait("Category", "GetUserInfoRequest")]
    public class GetUserInfoRequestTestes
    {
        [Fact]
        public void Construtor_DadoInstanciaSemValores_EntaoDeveSetarValoresDefaultCorretamente()
        {
            GetUserInfoRequest request = new();

            request.Claims.Should().BeEmpty();
        }
    }
}
