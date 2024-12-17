using eSistem.Dev.Estagio.Core.Requests.Account;
using FluentAssertions;

namespace eSistem.Dev.Estagio.CoreTestes.Tests.Requests.Account
{
    [Trait("Category", "LoginRequest")]
    public class LoginRequestTestes
    {
        [Fact]
        public void Construtor_DadoInstanciaSemValores_EntaoDeveSetarValoresDefaultCorretamente()
        {
            LoginRequest loginRequest = new();

            loginRequest.UserName.Should().BeEmpty();
            loginRequest.Password.Should().BeEmpty();
        }
    }
}
