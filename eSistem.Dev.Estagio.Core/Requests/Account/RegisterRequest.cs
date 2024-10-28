using eSistem.Dev.Estagio.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace eSistem.Dev.Estagio.Core.Requests.Account
{
    public class RegisterRequest
    {
        [Required(ErrorMessage="Este campo é obrigatório")]
        public string NomeRazaoSocial { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public ETipo Tipo { get; set; } = ETipo.Fisico;

        [Required(ErrorMessage = "Este documento é um campo obrigatório")]
       
        public string CpfCnpj { get; set; } = string.Empty;

        [Required(ErrorMessage="Usuário é um campo obrigatório")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage="Senha é um campo obrigatório")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage="A confirmação de senha é um campo obrigatório")]
        [Compare(nameof(Password), ErrorMessage="As senhas não conferem!")]
        public string ConfirmPassword { get; set; } = string.Empty;

    }
}
