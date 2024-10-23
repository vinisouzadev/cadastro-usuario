using eSistem.Dev.Estagio.Core.Requests;

namespace eSistem.Dev.Estagio.Core.Requests.Usuario
{
    public class DeleteUserRequest : Request
    {
        public string Id { get; set; } = string.Empty;

    }
}