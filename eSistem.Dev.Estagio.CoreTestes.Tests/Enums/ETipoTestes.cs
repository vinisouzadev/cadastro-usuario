using eSistem.Dev.Estagio.Core.Enums;

namespace eSistem.Dev.Estagio.CoreTestes.Tests.Enums
{
    [Trait("Category", "ETipo")]
    public sealed class ETipoTestes
    {
        [Fact]
        public static void Enum_DadoValorDoEnum_EntaoAssocieCorretamente()
        {
            int inputFisico = 0;
            int inputJuridico = 1;

            ETipo expectedETipoFisico= ETipo.Fisico;
            ETipo expectedETipoJuridico = ETipo.Juridico;

            Assert.Equal(expectedETipoFisico, (ETipo)inputFisico);
            Assert.Equal(expectedETipoJuridico, (ETipo)inputJuridico);
        }
    }
}
