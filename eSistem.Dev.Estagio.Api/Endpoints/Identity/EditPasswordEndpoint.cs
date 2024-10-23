using eSistem.Dev.Estagio.Api.Interfaces;
using eSistem.Dev.Estagio.Core.Handlers;
using eSistem.Dev.Estagio.Core.Requests.Usuario;
using eSistem.Dev.Estagio.Core.Responses;
using System.Security.Claims;

namespace eSistem.Dev.Estagio.Api.Endpoints.Identity
{
    public class EditPasswordEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder builder)
        {
            builder.MapPut("/edit-password", HandleAsync)
                .WithName("Account: Edit password")
                .WithDescription("Edita a senha do usuário")
                .Produces<Response<string?>>()
                .RequireAuthorization();
        }

        private static async Task<IResult> HandleAsync
            (IAccountHandler handler,
            EditPasswordRequest request,
            ClaimsPrincipal user)
        {
            request.UserId = user.Identity?.Name ?? string.Empty;

            var result = await handler.EditPasswordAsync(request);

            return result.IsSuccess
                ? TypedResults.NoContent()
                : TypedResults.BadRequest(result);
        }
    }
}
