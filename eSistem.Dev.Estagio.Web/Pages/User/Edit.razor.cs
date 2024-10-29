using eSistem.Dev.Estagio.Core.Requests.Usuario;
using eSistem.Dev.Estagio.Core;
using eSistem.Dev.Estagio.Core.Handlers;
using eSistem.Dev.Estagio.Web.Models;
using eSistem.Dev.Estagio.Web.Security;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace eSistem.Dev.Estagio.Web.Pages.User
{
    public partial class EditPageCode : ComponentBase
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

        public EditUserRequest InputModel { get; set; } = new();

        public bool IsBusy { get; set; } = false;

        public EditUserValidatorModel EditValidator { get; set; } = new();

        #endregion

        #region Parameters

        [Parameter]
        public string Id { get; set; } = string.Empty;

        #endregion

        #region Methods

        public async Task OnValidSubmitAsync()
        {
            if (!OnSubmitEditValidator())
                return;

            IsBusy = true;

            try
            {
                InputModel.Id = Id;

                var result = await Handler.EditUserAsync(InputModel);

                if (!result.IsSuccess)
                    Snackbar.Add(result.Message, Severity.Error);
                else
                {
                    if (Id == AuthenticationState.GetAuthenticadedUser()!.UserName)
                        AuthenticationState.NotifyAuthenticationStateChanged();

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

        #endregion

        #region Private Methods

        private bool OnSubmitEditValidator()
        {
            EditValidator = new();

            bool retorno = true;

            string adminUser = AuthenticationState.GetAuthenticadedUser()?.UserName ?? string.Empty;

            if (GenericServices.IsNullOrEmptyOrContainsSpace(InputModel.UserName))
                EditValidator.UserNameError.Add("O nome de usuário não pode estar vazio ou conter espaços");
            if (InputModel.UserName == adminUser)
                EditValidator.UserNameError.Add($"O nome de usuário é único e não deve ser o mesmo que o seu, '{adminUser}'");
            if (InputModel.UserName.Length > 256)
                EditValidator.UserNameError.Add("O nome de usuário não pode ter mais do que 256 caracteres");
            if (string.IsNullOrEmpty(InputModel.NomeRazaoSocial))
                EditValidator.NomeRazaoSocialError.Add("Este campo é obrigatório");

            if (!EditValidator.IsValid())
                retorno = false;

            return retorno;
        }

        #endregion
    }
}
