using eSistem.Dev.Estagio.Core.Models;
using FluentAssertions;
using k8s.Models;

namespace eSistem.Dev.Estagio.CoreTestes.Tests.Models
{
    [Trait("Category", "PessoaTestes")]
    public class PessoaTestes
    {
        [Fact]
        public void Construtor_DadoInstanciaSemValores_EntaoDeveSetarValoresDefaultCorretamente()
        {
            DateTime dateBeforeInstance = DateTime.UtcNow;

            Pessoa pessoa = new();

            DateTime dateAfterInstance = DateTime.UtcNow;

            pessoa.Id.Should().Be(0);
            pessoa.NomeRazaoSocial.Should().BeEmpty();
            pessoa.Tipo.Should().Be(0);
            pessoa.CpfCnpj.Should().BeEmpty();
            pessoa.Cadastro.Should().BeAfter(dateBeforeInstance).And.BeBefore(dateAfterInstance);
            pessoa.Ativo.Should().BeTrue();

        }
    }
}
