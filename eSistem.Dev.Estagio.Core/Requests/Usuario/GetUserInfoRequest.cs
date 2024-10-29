using eSistem.Dev.Estagio.Core.Requests;
using System.Security.Claims;

namespace eSistem.Dev.Estagio.Core.Requests.Usuario
{
    public class GetUserInfoRequest : Request
    {
        public IEnumerable<Claim> Claims = [];
    }
}