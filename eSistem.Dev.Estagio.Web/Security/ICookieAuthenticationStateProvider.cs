using eSistem.Dev.Estagio.Core.Models.Account;
using Microsoft.AspNetCore.Components.Authorization;

namespace eSistem.Dev.Estagio.Web.Security
{
    public interface ICookieAuthenticationStateProvider
    {
        Task<bool> CheckAuthenticatedAsync();

        Task<AuthenticationState> GetAuthenticationStateAsync();

        void NotifyAuthenticationStateChanged();

        Usuario? GetAuthenticadedUser();
    }
}
