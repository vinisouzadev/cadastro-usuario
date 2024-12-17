using eSistem.Dev.Estagio.Core.Requests.Usuario;
using FluentAssertions;

namespace eSistem.Dev.Estagio.CoreTestes.Tests.Requests.Usuario
{
    [Trait("Category", "EditUserRequest")]
    public class EditUserRequestTestes
    {
        [Fact]
        public void Construtor_DadoInstanciaSemValores_EntaoDeveSetarValoresDefaultCorretamente()
        {
            EditUserRequest request = new();

            request.Id.Should().BeEmpty();
            request.NomeRazaoSocial.Should().BeEmpty();
            request.UserName.Should().BeEmpty();
        }
    }
}
