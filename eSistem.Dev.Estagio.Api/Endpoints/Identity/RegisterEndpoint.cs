using eSistem.Dev.Estagio.Api.Interfaces;
using eSistem.Dev.Estagio.Core.Handlers;
using eSistem.Dev.Estagio.Core.Requests.Account;
using eSistem.Dev.Estagio.Core.Responses;

namespace eSistem.Dev.Estagio.Api.Endpoints.Identity
{
    public class RegisterEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder builder)
        {
            builder.MapPost("/register", HandleAsync)
                .WithName("Account: Register")
                .WithSummary("Realiza o registro de conta do usuário")
                .WithDescription("Realiza o registro de conta do usuário")
                .Produces<Response<string>>();
        }

        private static async Task<IResult> HandleAsync(RegisterRequest request, IAccountHandler handler)
        {
            var result = await handler.RegisterAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
