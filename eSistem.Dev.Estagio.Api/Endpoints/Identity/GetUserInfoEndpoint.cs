using eSistem.Dev.Estagio.Api.Interfaces;
using eSistem.Dev.Estagio.Core.Handlers;
using System.Security.Claims;

namespace eSistem.Dev.Estagio.Api.Endpoints.Identity
{
    public class GetUserInfoEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder builder)
        {
            builder.MapGet("/info", HandleAsync)
                .WithName("Account: Get user infos")
                .WithDescription("Retorna informações do usuário")
                .Produces<Core.Models.Account.Usuario?>();
        }

        private static IResult HandleAsync(IAccountHandler handler, ClaimsPrincipal user)
        {
            GetUserInfoRequest request = new()
            {
                UserId = user.Identity?.Name ?? string.Empty,
                Claims = user.Claims

            };

            var result = handler.GetUserInfoAsync(request);

            return result.Result.IsSuccess
                ? TypedResults.Ok(result.Result)
                : TypedResults.BadRequest(result.Result);
        }
    }
}
