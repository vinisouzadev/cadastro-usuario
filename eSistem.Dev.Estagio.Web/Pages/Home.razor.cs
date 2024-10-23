using eSistem.Dev.Estagio.Core.Handlers;
using eSistem.Dev.Estagio.Core.Models;
using eSistem.Dev.Estagio.Core.Models.Account;
using eSistem.Dev.Estagio.Core.Requests.Usuario;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Security.Cryptography.X509Certificates;

namespace eSistem.Dev.Estagio.Web.Pages
{
    public partial class EditPageCode : ComponentBase
    {
        #region Dependências

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public IAccountHandler Handler { get; set; } = null!;

        [Inject]
        public IDialogService DialogService { get; set; } = null!;

        #endregion

        #region Propriedades

        public List<Usuario?> Usuarios { get; set; } = [];

        public bool IsBusy { get; set; } = false;

        #endregion

        #region Overrides

        protected override async Task OnInitializedAsync()
        {
            var request = new GetAllUsersRequest();
            var result = await Handler.GetAllUsersAsync(request);
            
            if (result.IsSuccess)
                Usuarios = result.Data ?? [];
            else
                Snackbar.Add(result.Message, Severity.Error);
        }

        #endregion

        #region Metodos

        public async Task OnDeleteBottomClickedAsync(string id)
        {
                bool? resultDialog = await DialogService.ShowMessageBox("ATENÇÃO", "Você está prestes a deletar um usuário. Tem certeza disto?",
                    yesText: "Sim", cancelText: "Cancelar");
            
            if(resultDialog is true)
            {
                var request = new DeleteUserRequest() { Id = id };
                var result = await Handler.DeleteUserAsync(request);

                if (result.IsSuccess)
                {
                    Usuarios.RemoveAll(x => x!.UserName == id);
                    Snackbar.Add(result.Message, Severity.Success);
                    StateHasChanged();
                }
                else
                {
                    Snackbar.Add(result.Message, Severity.Error);
                }
                    
            }
        }

        #endregion



    }
}
