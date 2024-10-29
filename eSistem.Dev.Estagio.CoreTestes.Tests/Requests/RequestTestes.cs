using eSistem.Dev.Estagio.Core.Requests;
using FluentAssertions;

namespace eSistem.Dev.Estagio.CoreTestes.Tests.Requests
{
    [Trait("Category", "Request")]
    public class RequestTestes
    {
        [Fact]
        public void Construtor_DadoInstanciaSemValores_EntaoDeveSetarValoresDefaultCorretamente()
        {
            Request request = new();

            request.UserId.Should().BeEmpty();
        }
    }
}
