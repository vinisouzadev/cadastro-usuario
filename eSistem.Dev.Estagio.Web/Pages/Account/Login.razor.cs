using eSistem.Dev.Estagio.Core;
using eSistem.Dev.Estagio.Core.Handlers;
using eSistem.Dev.Estagio.Core.Requests.Account;
using eSistem.Dev.Estagio.Web.Models;
using eSistem.Dev.Estagio.Web.Security;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace eSistem.Dev.Estagio.Web.Pages.Account
{
    public partial class LoginPageCode : ComponentBase
    {
        #region Propriedades

        public LoginRequest InputModel { get; set; } = new();

        public bool IsBusy { get; set; } = false;

        public bool ToggleVisibility = false;

        public LoginValidatorModel LoginValidator { get; set; } = new();

        #endregion

        #region Dependências

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public IAccountHandler Handler { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ICookieAuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;

        #endregion

        #region Overrides

        protected override async Task OnInitializedAsync()
        {
            if (AuthenticationStateProvider.GetAuthenticadedUser() is not null)
                NavigationManager.NavigateTo("/");
        }

        #endregion

        #region Methods

        public async Task OnValidSubmitAsync()
        {
            if (!OnSubmitLoginValidator())
                return;

            IsBusy = true;

            try
            {
                var result = await Handler.LoginAsync(InputModel);

                if (!result.IsSuccess)
                    Snackbar.Add(result.Message, Severity.Error);
                else
                {
                    await AuthenticationStateProvider.GetAuthenticationStateAsync();
                    AuthenticationStateProvider.NotifyAuthenticationStateChanged();
                    NavigationManager.NavigateTo("/");
                }

            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnVisibilityIconClickedAsync()
        {
            ToggleVisibility = !ToggleVisibility;
        }
        #endregion

        #region Private Methods

        private bool OnSubmitLoginValidator()
        {
            LoginValidator = new();

            bool retorno = true;

            #region Validar UserName

            if (GenericServices.IsNullOrEmptyOrContainsSpace(InputModel.UserName))
                LoginValidator.UserNameError.Add("O nome de usuário não pode ser nulo ou conter espaços");
            if (InputModel.UserName.Length > 256)
                LoginValidator.UserNameError.Add("O nome de usuário não pode conter mais de 256 caracteres");

            #endregion

            #region Validar Password

            if (GenericServices.IsNullOrEmptyOrContainsSpace(InputModel.Password))
                LoginValidator.PasswordError.Add("A senha não pode estar vazia ou conter espaços");
            if (InputModel.Password.Length > 30)
                LoginValidator.PasswordError.Add("A senha não pode conter mais de 30 caracteres");

            if (!LoginValidator.IsValid())
                retorno = false;

            #endregion
            return retorno;
        }

        #endregion
    }
}
