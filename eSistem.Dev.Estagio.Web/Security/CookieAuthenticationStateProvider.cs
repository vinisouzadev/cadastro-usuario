using eSistem.Dev.Estagio.Core.Models;
using eSistem.Dev.Estagio.Core.Models.Account;
using eSistem.Dev.Estagio.Core.Responses;
using eSistem.Dev.Estagio.Web.Common;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using System.Security.Claims;

namespace eSistem.Dev.Estagio.Web.Security
{
    public class CookieAuthenticationStateProvider(IHttpClientFactory httpClientFactory) : AuthenticationStateProvider, ICookieAuthenticationStateProvider
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient(Configuration.HttpName);

        private bool IsAuthenticated;

        public Usuario? Usuario = null;

        public async Task<bool> CheckAuthenticatedAsync()
        {
            await GetAuthenticationStateAsync();
            return IsAuthenticated;
        }

        public void NotifyAuthenticationStateChanged()
            => NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            Usuario = null;
            IsAuthenticated = false;

            var user = new ClaimsPrincipal(new ClaimsIdentity());

            Usuario? userInfo = await GetUserAsync();

            if (userInfo is null)
                return new AuthenticationState(user);

            var claims = await GetClaimsAsync(userInfo);

            var id = new ClaimsIdentity(claims, nameof(CookieAuthenticationStateProvider));

            user = new ClaimsPrincipal(id);

            IsAuthenticated = true;
            Usuario = userInfo;
            foreach(var claim in claims)
            {
                if (string.IsNullOrEmpty(claim.Type) && string.IsNullOrEmpty(claim.Value))
                    Usuario.Claims.Add(claim.Type, claim.Value);
            }
            return new AuthenticationState(user);
        }

        private async Task<Usuario?> GetUserAsync() 
        {
            try
            {
                var user =  await _httpClient.GetFromJsonAsync<Response<Usuario?>>("v1/account/info");

                return user.Data;
            }
            catch
            {
                return null;
            }
        }

        private async Task<List<Claim?>> GetClaimsAsync(Usuario? usuario)
        {
            var claims = new List<Claim?>()
            {
                new (ClaimTypes.Name, usuario!.UserName)
            };

            RoleClaim[] roles;

            claims.AddRange(usuario.Claims
                                    .Where(x => x.Key != usuario.UserName && x.Value != usuario.UserName)
                                    .Select(x => new Claim(x.Key, x.Value))
                           );

            try
            {
                roles = await _httpClient.GetFromJsonAsync<RoleClaim[]>("v1/account/roles") ?? [];
            }
            catch
            {
                return claims;
            }

            foreach(var role in roles)
            {   
                if(!string.IsNullOrEmpty(role.Type) && !string.IsNullOrEmpty(role.Value))
                    claims.Add(new Claim(role.Type , role.Value, role.ValueType, role.Issuer, role.OriginalIssuer));
            }

            return claims;
        }

        public Usuario? GetAuthenticadedUser()
            => Usuario;
    }
}
