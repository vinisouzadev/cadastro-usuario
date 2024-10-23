using eSistem.Dev.Estagio.Api.Endpoints.Identity;
using eSistem.Dev.Estagio.Core.Handlers;
using eSistem.Dev.Estagio.Core.Models.Account;
using eSistem.Dev.Estagio.Core.Requests.Account;
using eSistem.Dev.Estagio.Core.Requests.Usuario;
using eSistem.Dev.Estagio.Core.Responses;
using eSistem.Dev.Estagio.Web.Common;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;

namespace eSistem.Dev.Estagio.Web.Handlers
{
    public class AccountHandler(IHttpClientFactory factory) : IAccountHandler
    {
        private readonly HttpClient _client = factory.CreateClient(Configuration.HttpName);

        public async Task<Response<bool>> ConfirmedPasswordAsync(ConfirmedPasswordRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/account/confirm-password", request);

            return result.IsSuccessStatusCode
                ? new Response<bool>(true, 200, "Sucesso")
                : new Response<bool>(false, 400, "Falha");
        }

        public async Task<Response<string?>> DeleteUserAsync(DeleteUserRequest request)
        {
            var result = await _client.DeleteAsync($"v1/account/{request.Id}");

            return result.IsSuccessStatusCode
                ? new Response<string?>(string.Empty, 204, "Conta deletada com sucesso!")
                : new Response<string?>(string.Empty, 400, "Falha ao deletar conta");

        }

        public async Task<Response<string?>> EditPasswordAsync(EditPasswordRequest request)
        {   
            var result = await _client.PutAsJsonAsync("v1/account/edit-password", request);

            return result.IsSuccessStatusCode
                ? new Response<string?>(string.Empty, 204, "Senha atualizada com sucesso")
                : await result.Content.ReadFromJsonAsync<Response<string?>>() ??
                    new Response<string?>("", 400, "Não foi possível atualizar a senha");
        }
         
        public async Task<Response<Usuario?>> EditUserAsync(EditUserRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Id))
                return new Response<Usuario?>(null, 400, "Usuário não encontrado");

            var result = await _client.PutAsJsonAsync($"v1/account/edit/{request.Id}", request);
            var response = await result.Content.ReadFromJsonAsync<Response<Usuario?>>();

            return result.IsSuccessStatusCode
                ? new Response<Usuario?>(response!.Data, response!.StatusCode, response.Message)
                : new Response<Usuario?>(response?.Data, response!.StatusCode, response.Message);

        }

        public async Task<PagedResponse<List<Usuario?>>> GetAllUsersAsync(GetAllUsersRequest request)
        {
            var result = await _client.GetFromJsonAsync<PagedResponse<List<Usuario?>>>("v1/account/user");

            return result!.IsSuccess
                ? new PagedResponse<List<Usuario?>>(result.Data, result.StatusCode, result.Message)
                : new PagedResponse<List<Usuario?>>(result.Data, result.StatusCode, result.Message);
        }

        public async Task<Response<Usuario?>> GetUserInfoAsync(GetUserInfoRequest request)
        {
            var result = await _client.GetFromJsonAsync<Response<Usuario?>>("v1/account/info");

            return result!.IsSuccess
                ? new Response<Usuario?>(result.Data, result.StatusCode, result.Message)
                : new Response<Usuario?>(result.Data, result.StatusCode, result.Message);
        }

        public async Task<Response<string?>> LoginAsync(LoginRequest request)
        {
            //validar a request 
            var result = await _client.PostAsJsonAsync("v1/account/login", request);
            var response = await result.Content.ReadFromJsonAsync<Response<string?>>();

            return result.IsSuccessStatusCode
                ? new Response<string?>(response?.Data, response!.StatusCode, response.Message)
                : new Response<string?>(response?.Data, response!.StatusCode, response.Message);
        }

        public async Task<Response<string?>> LogoutAsync()
        {
            var stringEmpty = new StringContent("{}", encoding: Encoding.UTF8, "application/json");
            var result = await _client.PostAsJsonAsync("v1/account/logout", stringEmpty);
            var response = await result.Content.ReadFromJsonAsync<Response<string?>>();

            return result.IsSuccessStatusCode
                ? new Response<string?>(response?.Data, response!.StatusCode, response.Message)
                : new Response<string?>(response?.Data, response!.StatusCode, response.Message);
        }

        public async Task<Response<string?>> RegisterAsync(RegisterRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/account/register", request);
            var response = await result.Content.ReadFromJsonAsync<Response<string?>>();
            return result.IsSuccessStatusCode
                ? new Response<string?>(response?.Data, response!.StatusCode, response.Message)
                : new Response<string?>(response?.Data, response!.StatusCode, response.Message);
        }

        
    }
}
