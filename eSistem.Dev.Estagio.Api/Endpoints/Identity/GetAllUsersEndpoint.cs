using eSistem.Dev.Estagio.Api.Interfaces;
using eSistem.Dev.Estagio.Core.Handlers;
using eSistem.Dev.Estagio.Core.Requests.Usuario;
using System.Security.Claims;

namespace eSistem.Dev.Estagio.Api.Endpoints.Identity
{
    public class GetAllUsersEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder builder)
        {
            builder.MapGet("/user", HandleAsync)
                .WithName("Account: Get all users")
                .WithDescription("Retorna todos os usuários do banco")
                .RequireAuthorization();
        }

        private static async Task<IResult> HandleAsync(ClaimsPrincipal user, IAccountHandler handler)
        {
            var request = new GetAllUsersRequest()
            {
                UserId = user.Identity!.Name ?? string.Empty
            };

            var result = await handler.GetAllUsersAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);

        }
    }
}
