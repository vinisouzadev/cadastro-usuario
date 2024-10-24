using eSistem.Dev.Estagio.Core.Enums;

namespace eSistem.Dev.Estagio.CoreTestes.Tests.Enums
{
    [Trait("Category", "ETipo")]
    public sealed class EnumTestes
    {
        [Fact]
        public static void Enum_DadoValorDoEnum_EntaoAssocieCorretamente()
        {

            ETipo tipo = (ETipo)1;
            ETipo tipo2 = 0;

            Assert.Equal(ETipo.Juridico, tipo);
            Assert.Equal(ETipo.Fisico, tipo2);
        }
    }
}
