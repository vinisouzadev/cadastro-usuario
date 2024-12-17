using eSistem.Dev.Estagio.Core.Requests.Usuario;
using FluentAssertions;

namespace eSistem.Dev.Estagio.CoreTestes.Tests.Requests.Usuario
{
    [Trait("Category", "GetAllUserRequest")]
    public class GetAllUserRequestTestes
    {
        [Fact]
        public void Construtor_DadoInstanciaSemValores_EntaoDeveSetarValoresDefaultNasPropriedadesCorretamente()
        {
            GetAllUsersRequest request = new();

            request.Claims.Should().BeEmpty();   
        }
    }
}
