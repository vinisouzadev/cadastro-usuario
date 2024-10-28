using eSistem.Dev.Estagio.Core.Requests.Usuario;
using FluentAssertions;

namespace eSistem.Dev.Estagio.CoreTestes.Tests.Requests.Usuario
{
    [Trait("Category", "EditPasswordRequest")]
    public class EditPasswordRequestTestes
    {
        [Fact]
        public void Construtor_DadoInstanciaSemValores_EntaoDeveSetarPropriedadesDefaultCorretamente()
        {
            EditPasswordRequest request = new();

            request.CurrentPassword.Should().BeEmpty();
            request.Password.Should().BeEmpty();
            request.ConfirmPassword.Should().BeEmpty();
        }
    }
}
