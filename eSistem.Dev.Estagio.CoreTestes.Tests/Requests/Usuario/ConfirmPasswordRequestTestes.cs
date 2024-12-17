using eSistem.Dev.Estagio.Core.Requests.Usuario;
using FluentAssertions;

namespace eSistem.Dev.Estagio.CoreTestes.Tests.Requests.Usuario
{
    [Trait("Category", "ConfirmPasswordRequest")]
    public class ConfirmPasswordRequestTestes
    {
        [Fact]
        public void Construtor_DadoInstanciaSemValores_EntaoDeveSetarValoresDefaultCorretamente()
        {
            ConfirmedPasswordRequest request = new();

            request.Password.Should().BeEmpty();
        }
    }
}
