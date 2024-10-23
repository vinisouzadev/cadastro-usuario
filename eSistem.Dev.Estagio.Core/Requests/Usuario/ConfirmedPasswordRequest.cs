using System.ComponentModel.DataAnnotations;

namespace eSistem.Dev.Estagio.Core.Requests.Usuario
{
    public class ConfirmedPasswordRequest : Request
    {
        [Required(ErrorMessage = "O campo de senha é obrigatório")]
        public string Password { get; set; } = string.Empty;
    }
}