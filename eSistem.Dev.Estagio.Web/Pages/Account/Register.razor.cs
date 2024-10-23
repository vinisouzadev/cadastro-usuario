using eSistem.Dev.Estagio.Core;
using eSistem.Dev.Estagio.Core.Enums;
using eSistem.Dev.Estagio.Core.Handlers;
using eSistem.Dev.Estagio.Core.Requests.Account;
using eSistem.Dev.Estagio.Web.Models;
using eSistem.Dev.Estagio.Web.Security;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace eSistem.Dev.Estagio.Web.Pages.Account
{
    public partial class RegisterPageCode : ComponentBase
    {

        #region Dependências

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public IAccountHandler Handler { get; set; } = null!;

        [Inject]
        public ICookieAuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;

        #endregion

        #region Propriedades
        public RegisterRequest InputModel { get; set; } = new();

        public bool IsBusy { get; set; } = false;

        public bool ToggleVisibility = false;

        public RegisterUserValidatorModel UserValidator { get; set; } = new();

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
            if (!OnSubmitRegisterValidador())
                return;

            IsBusy = true;

            try
            {
                var result = await Handler.RegisterAsync(InputModel);

                if (!result.IsSuccess)
                    Snackbar.Add(result.Message, Severity.Error);
                else
                    NavigationManager.NavigateTo("/login");


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
        
        public void OnVisibilityIconClicked()
        {
            ToggleVisibility = !ToggleVisibility;
        }

        #endregion

        #region Private Methods

        private bool OnSubmitRegisterValidador()
        {
            UserValidator = new();

            bool retorno = true;

            #region Validar Nome/RazãoSocial

            if (string.IsNullOrEmpty(InputModel.NomeRazaoSocial))
                UserValidator.NomeRazaoSocialError.Add($"Este campo é obrigatório.");

            if (InputModel.NomeRazaoSocial.Length > 150)
                UserValidator.NomeRazaoSocialError.Add($"Este campo não pode conter mais que 150 caracteres.");

            #endregion

            #region Validar CPF/CNPJ

            string tipoMessage = InputModel.Tipo == Core.Enums.ETipo.Fisico
                    ? "CPF"
                    : "CNPJ";

            bool cpfCnpjIsNumber = Configuration.CpfCnpjFormatVerify(InputModel.CpfCnpj);

            tipoMessage = InputModel.Tipo == Core.Enums.ETipo.Fisico
                    ? "CPF"
                    : "CNPJ";

            if (GenericServices.IsNullOrEmptyOrContainsSpace(InputModel.CpfCnpj))
                UserValidator.CpfCnpjError.Add($"O {tipoMessage} não pode estar vazio ou conter espaços");

            if (!cpfCnpjIsNumber)
                UserValidator.CpfCnpjError.Add($"O {tipoMessage} deve conter apenas números.");

            switch (InputModel.Tipo)
            {
                case Core.Enums.ETipo.Fisico:
                    {
                        if (InputModel.CpfCnpj.Length != 11)
                            UserValidator.CpfCnpjError.Add($"O {tipoMessage} deve conter exatamente 11 digitos.");
                    }
                    break;

                case Core.Enums.ETipo.Juridico:
                    {
                        if (InputModel.CpfCnpj.Length != 14)
                            UserValidator.CpfCnpjError.Add($"O {tipoMessage} deve conter exatamente 14 digitos.");
                    }
                    break;
            }

            #endregion

            #region Validar Username

            if (GenericServices.IsNullOrEmptyOrContainsSpace(InputModel.UserName))
                UserValidator.UserNameError.Add("Este campo não pode estar vazio ou conter espaços");
            if (InputModel.UserName.Length > 256)
                UserValidator.UserNameError.Add("Este campo não pode conter mais de 256 caracteres");

            #endregion

            #region Validar Password e ConfirmPassword

            if (GenericServices.IsNullOrEmptyOrContainsSpace(InputModel.Password))
                UserValidator.PasswordError.Add("A senha não pode estar vazia ou conter espaços");
            if (GenericServices.IsNullOrEmptyOrContainsSpace(InputModel.ConfirmPassword))
                UserValidator.ConfirmPasswordError.Add("A confirmação de senha é um campo obrigatório");
            //if(InputModel.Password.Length > 30)
            //    UserValidator.PasswordError.Add("A senha não pode ter mais de 30 caracteres");
            if (InputModel.Password != InputModel.ConfirmPassword)
                UserValidator.ConfirmPasswordError.Add("As senhas não conferem");

            #endregion
            if (!UserValidator.IsValid())
                retorno = false;


            return retorno;
        }

        #endregion

    }
}
