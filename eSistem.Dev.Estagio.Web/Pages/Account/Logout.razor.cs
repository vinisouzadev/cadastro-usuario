using eSistem.Dev.Estagio.Core.Handlers;
using eSistem.Dev.Estagio.Web.Security;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace eSistem.Dev.Estagio.Web.Pages.Account
{
    public partial class LogoutPageCode : ComponentBase
    {
        #region Dependências

        [Inject]
        public ICookieAuthenticationStateProvider AuthenticationState { get; set; } = null!;

        [Inject]
        public IAccountHandler Handler { get; set; } = null!;

        #endregion

        #region Overrides

        protected override async Task OnInitializedAsync()
        {   


            if(await AuthenticationState.CheckAuthenticatedAsync())
            {
                await Handler.LogoutAsync();

                AuthenticationState.NotifyAuthenticationStateChanged();
            }
            
            await base.OnInitializedAsync();
        }

        #endregion



    }
}
