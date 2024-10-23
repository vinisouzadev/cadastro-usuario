using eSistem.Dev.Estagio.Api.Endpoints.Identity;
using eSistem.Dev.Estagio.Core.Models.Account;
using eSistem.Dev.Estagio.Core.Requests.Account;
using eSistem.Dev.Estagio.Core.Requests.Usuario;
using eSistem.Dev.Estagio.Core.Responses;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace eSistem.Dev.Estagio.Core.Handlers
{
    public interface IAccountHandler
    {
        Task<Response<string?>> RegisterAsync(RegisterRequest request);

        Task<Response<string?>> LoginAsync(LoginRequest request);

        Task<Response<string?>> LogoutAsync();

        Task<Response<Usuario?>> GetUserInfoAsync(GetUserInfoRequest request);

        Task<PagedResponse<List<Usuario?>>> GetAllUsersAsync(GetAllUsersRequest request);

        Task<Response<Usuario?>> EditUserAsync(EditUserRequest request);

        Task<Response<string?>> EditPasswordAsync(EditPasswordRequest request);

        Task<Response<string?>> DeleteUserAsync(DeleteUserRequest request);
    }
}
