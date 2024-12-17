using Bogus;
using Bogus.Extensions;
using eSistem.Dev.Estagio.Core.Models.Account;
using FluentAssertions;

namespace eSistem.Dev.Estagio.CoreTestes.Tests.Models
{
    [Trait("Category", "Usuario")]
    public class UsuarioTestes
    {
        [Fact]
        public void Construtor_DadoInstanciaSemValores_EntaoDeveSetarValoresDefaultCorretamente()
        {
            Usuario usuario = new();

            usuario.UserName.Should().BeEmpty();
            usuario.Claims.Should().BeEmpty();
            usuario.Person.Should().NotBeNull();
        }
    }
}
