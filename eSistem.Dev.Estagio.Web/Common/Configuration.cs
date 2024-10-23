using MudBlazor;
using MudBlazor.Extensions;
using MudBlazor.Utilities;
using System.Net.NetworkInformation;

namespace eSistem.Dev.Estagio.Web.Common
{
    public class Configuration
    {
        public const string HttpName = "esistem";

        public static string BackendUrl { get; set; } = string.Empty;

        public static MudThemeProvider ThemeProvider = new();

        public static MudTheme Theme = new()
        {

            PaletteLight = new()
            {
                Primary = new MudColor("00ab7f"),
                Secondary = new MudColor("008964"),
                Background = new MudColor("ededed"),
                DrawerBackground = new MudColor("004230"),
                DrawerIcon = new MudColor("defcf3"),
                DrawerText = new MudColor("defcf3"),
                AppbarBackground = new MudColor("004230"),
                AppbarText = new MudColor("defcf3"),

                
            }

        };
    }
}
