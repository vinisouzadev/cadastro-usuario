using eSistem.Dev.Estagio.Api.Interfaces;
using eSistem.Dev.Estagio.Core.Handlers;
using eSistem.Dev.Estagio.Core.Requests.Account;
using eSistem.Dev.Estagio.Core.Responses;

namespace eSistem.Dev.Estagio.Api.Endpoints.Identity
{
    public class LoginEndpoint : IEndpoint
    {   
        public static void Map(IEndpointRouteBuilder builder)
        {
            builder.MapPost("/login", HandleAsync)
                .WithName("Account: Login")
                .WithSummary("Realiza o login do usuário")
                .WithDescription("Realiza o login do usuário")
                .Produces<Response<string?>>();
        }

        private static async Task<IResult> HandleAsync(LoginRequest request, IAccountHandler handler)
        {
            var result = await handler.LoginAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
