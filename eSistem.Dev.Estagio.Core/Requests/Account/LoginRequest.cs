using System.ComponentModel.DataAnnotations;

namespace eSistem.Dev.Estagio.Core.Requests.Account
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "O campo de nome de usuário é obrigatório!")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo de senha é obrigatório")]
        public string Password { get; set; } = string.Empty;

    }
}
