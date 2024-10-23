using Microsoft.AspNetCore.Identity;

namespace eSistem.Dev.Estagio.Api.Models.Identity
{
    public class Usuario : IdentityUser
    {
        public int IdPessoa { get; set; }

        public bool Ativo { get; set; } = true;

        public PessoaWithUser Pessoa { get; set; } = null!;
    }
}
