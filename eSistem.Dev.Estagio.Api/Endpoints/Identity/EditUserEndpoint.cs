using eSistem.Dev.Estagio.Api.Interfaces;
using eSistem.Dev.Estagio.Core.Handlers;
using eSistem.Dev.Estagio.Core.Requests.Usuario;
using eSistem.Dev.Estagio.Core.Responses;
using System.Security.Claims;

namespace eSistem.Dev.Estagio.Api.Endpoints.Identity
{
    public class EditUserEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder builder)
        {
            builder.MapPut("/edit/{id}", HandleAsync)
                .WithName("Account: Edit user")
                .WithDescription("Edita um usuário")
                .Produces<Response<Core.Models.Account.Usuario?>>()
                .RequireAuthorization();
        }

        private static async Task<IResult> HandleAsync(string id,IAccountHandler handler, ClaimsPrincipal user, EditUserRequest request)
        {
            if (!user.IsInRole("Admin") || !user.Identity.IsAuthenticated)
                return TypedResults.Forbid();

            request.Id = id;
            request.UserId = user.Identity?.Name ?? string.Empty;

            var result = await handler.EditUserAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
