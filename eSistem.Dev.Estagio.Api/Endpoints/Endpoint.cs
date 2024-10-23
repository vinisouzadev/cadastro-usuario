using eSistem.Dev.Estagio.Api.Endpoints.Identity;
using eSistem.Dev.Estagio.Api.Interfaces;


namespace eSistem.Dev.Estagio.Api.Endpoints
{
    public static class Endpoint
    {   
        public static void MapEndpointsGroups(this WebApplication app)
        {
            var endpoint = app.MapGroup("/");

            endpoint.MapGroup("v1/account")
                .WithTags("Account")
                .MapEndpoint<RegisterEndpoint>()
                .MapEndpoint<LoginEndpoint>()
                .MapEndpoint<GetRolesEndpoint>()
                .MapEndpoint<LogoutEndpoint>()
                .MapEndpoint<GetUserInfoEndpoint>()
                .MapEndpoint<EditPasswordEndpoint>()
                .MapEndpoint<GetAllUsersEndpoint>()
                .MapEndpoint<DeleteUserEndpoint>()
                .MapEndpoint<EditUserEndpoint>();
        } 

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app) where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
}
