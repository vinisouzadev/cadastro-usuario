using eSistem.Dev.Estagio.Core.Requests.Account;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSistem.Dev.Estagio.CoreTestes.Tests.Requests.Account
{
    [Trait("Category", "RegisterRequest")]
    public class RegisterRequestTestes
    {
        [Fact]
        public void Construtor_DadoInstanciaSemValores_EntaoDeveSetarPropriedadesDefaultCorretamente()
        {
            RegisterRequest request = new();

            request.NomeRazaoSocial.Should().BeEmpty();
            request.Tipo.Should().Be(0);
            request.CpfCnpj.Should().BeEmpty();
            request.UserName.Should().BeEmpty();
            request.Password.Should().BeEmpty();
            request.ConfirmPassword.Should().BeEmpty();
        }
    }
}
