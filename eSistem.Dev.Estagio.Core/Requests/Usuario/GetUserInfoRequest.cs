using eSistem.Dev.Estagio.Core.Requests;
using System.Security.Claims;

namespace eSistem.Dev.Estagio.Api.Endpoints.Identity
{
    public class GetUserInfoRequest : Request
    {
        public IEnumerable<Claim> Claims = [];
    }
}