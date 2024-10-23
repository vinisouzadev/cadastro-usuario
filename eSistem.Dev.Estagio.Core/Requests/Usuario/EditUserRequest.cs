using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace eSistem.Dev.Estagio.Core.Requests.Usuario
{
    public class EditUserRequest : Request
    {
        public string Id { get; set; } = string.Empty;

        public string? NomeRazaoSocial { get; set; } = string.Empty;

        public string? UserName { get; set; } = string.Empty;

    }
}
