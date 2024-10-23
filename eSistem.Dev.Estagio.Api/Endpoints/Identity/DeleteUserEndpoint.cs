using eSistem.Dev.Estagio.Api.Interfaces;
using eSistem.Dev.Estagio.Core.Handlers;
using eSistem.Dev.Estagio.Core.Requests.Usuario;
using eSistem.Dev.Estagio.Core.Responses;
using System.Security.Claims;

namespace eSistem.Dev.Estagio.Api.Endpoints.Identity
{
    public class DeleteUserEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder builder)
        {
            builder.MapDelete("{id}", HandleAsync)
                .WithName("Account: Delete")
                .WithDescription("Deleta um usuário")
                .Produces<Response<string?>>()
                .RequireAuthorization();
        }

        private static async Task<IResult> HandleAsync(string id,IAccountHandler handler, ClaimsPrincipal user)
        {   
            if (!user.Identity.IsAuthenticated || !user.IsInRole("Admin"))
                return TypedResults.Forbid();

            var request = new DeleteUserRequest
            {
                Id = id, UserId = user.Identity?.Name ?? string.Empty
            };

            var result = await handler.DeleteUserAsync(request);

            return result.IsSuccess
                ? TypedResults.NoContent()
                : TypedResults.BadRequest(result);

            
        }
    }
}
