using eSistem.Dev.Estagio.Core.Requests;
using System.Security.Claims;

namespace eSistem.Dev.Estagio.Core.Requests.Usuario
{
    public class GetAllUsersRequest : PagedRequest
    {
        public List<Claim> Claims { get; set; } = [];
    }
}