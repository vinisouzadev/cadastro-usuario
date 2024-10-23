using eSistem.Dev.Estagio.Core.Requests;
using System.ComponentModel.DataAnnotations;

namespace eSistem.Dev.Estagio.Core.Requests.Usuario
{
    public class EditPasswordRequest : Request
    {
        [Required(ErrorMessage = "A senha é obrigatória")]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "A confirmação de senha é obrigatória")]
        [Compare(nameof(Password), ErrorMessage = "As senhas não conferem!")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}