using eSistem.Dev.Estagio.Core;
using eSistem.Dev.Estagio.Core.Handlers;
using eSistem.Dev.Estagio.Core.Requests.Usuario;
using eSistem.Dev.Estagio.Web.Models;
using eSistem.Dev.Estagio.Web.Security;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Runtime.CompilerServices;

namespace eSistem.Dev.Estagio.Web.Pages.User
{
    public partial class EditPasswordPageCode : ComponentBase
    {
        #region Dependências

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public IAccountHandler Handler { get; set; } = null!;

        [Inject]
        public ICookieAuthenticationStateProvider AuthenticationState { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        #endregion

        #region Propriedades

        public EditPasswordRequest InputModel { get; set; } = new();

        public bool IsBusy { get; set; } = false;

        public EditPasswordValidatorModel EditValidator { get; set; } = new();

        public bool ToggleVisibility { get; set; } = false;

        #endregion

        #region Methods

        public async Task OnValidSubmitAsync()
        {
            if (!OnSubmitEditValidator())
                return;

            IsBusy = true;

            try
            {
                var result = await Handler.EditPasswordAsync(InputModel);

                if (!result.IsSuccess)
                    Snackbar.Add(result.Message, Severity.Error, option =>
                    {
                        option.HideTransitionDuration = 1;
                    });
                else
                {
                    Snackbar.Add(result.Message, Severity.Success);

                    AuthenticationState.NotifyAuthenticationStateChanged();
                }


            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error, options =>
                {
                    options.HideTransitionDuration = 1;
                });
            }
            finally
            {
                IsBusy = false;
            }

        }

        public void OnToggleVisibilityBottomCliked()
        {
            ToggleVisibility = !ToggleVisibility;
        }

        #endregion

        #region Private Methods

        private bool OnSubmitEditValidator()
        {
            EditValidator = new();

            bool retorno = true;

            string currentPassword = InputModel.CurrentPassword;
            string password = InputModel.Password;
            string confirmPassword = InputModel.ConfirmPassword;

            string nullOrEmptyErrorMessage = "Este campo não pode estar vazio ou conter espaços";
            string maxLenghtError = "Este campo não pode conter mais de 30 caracteres";

            if (GenericServices.IsNullOrEmptyOrContainsSpace(currentPassword))
                EditValidator.CurrentPasswordError.Add(nullOrEmptyErrorMessage);
            if (currentPassword.Length > 30)
                EditValidator.CurrentPasswordError.Add(maxLenghtError);
            if (GenericServices.IsNullOrEmptyOrContainsSpace(password))
                EditValidator.PasswordError.Add(nullOrEmptyErrorMessage);
            if (password.Length > 30)
                EditValidator.PasswordError.Add(maxLenghtError);
            if (GenericServices.IsNullOrEmptyOrContainsSpace(confirmPassword))
                EditValidator.ConfirmPasswordError.Add(nullOrEmptyErrorMessage);
            if (password != confirmPassword)
                EditValidator.ConfirmPasswordError.Add("As senhas não conferem.");

            if(!EditValidator.IsValid())
                return false;

            return retorno;
        }

        #endregion
    }
}
