using eSistem.Dev.Estagio.Api.Interfaces;
using eSistem.Dev.Estagio.Api.Models.Identity;
using eSistem.Dev.Estagio.Core.Handlers;
using Microsoft.AspNetCore.Identity;

namespace eSistem.Dev.Estagio.Api.Endpoints.Identity
{
    public class LogoutEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder builder)
        {
            builder.MapPost("/logout", HandleAsync)
                .WithName("Account: Logout")
                .WithDescription("Faz o logout do usuário")
                .RequireAuthorization();
        }

        private static async Task<IResult> HandleAsync(SignInManager<Usuario> signInManager, IAccountHandler handler)
        {
            var result = await handler.LogoutAsync();

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
