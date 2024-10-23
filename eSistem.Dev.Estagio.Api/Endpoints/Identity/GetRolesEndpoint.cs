using eSistem.Dev.Estagio.Api.Interfaces;
using eSistem.Dev.Estagio.Core.Models;
using System.Security.Claims;

namespace eSistem.Dev.Estagio.Api.Endpoints.Identity
{
    public class GetRolesEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder builder)
        {
            builder.MapGet("/roles", HandleAsync)
                .WithName("Account: Get Roles")
                .WithDescription("Retorna as roles do usuário")
                .RequireAuthorization();
        }

        private static IResult HandleAsync(ClaimsPrincipal usuario)
        {
            if (usuario.Identity is null || !usuario.Identity.IsAuthenticated)
                return TypedResults.Unauthorized();

            var identity = (ClaimsIdentity)usuario.Identity;

            var roles = identity.FindAll(identity.RoleClaimType).Select(x => new RoleClaim
            {
                Issuer = x.Issuer,
                OriginalIssuer = x.OriginalIssuer,
                Type = x.Type,
                Value = x.Value,
                ValueType = x.ValueType
            });

            return TypedResults.Json(roles);
        }
    }
}
