using eSistem.Dev.Estagio.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace eSistem.Dev.Estagio.Api.Models.Identity
{
    public class Usuario : IdentityUser
    {
        public int IdPerson { get; set; }

        public bool Ativo { get; set; } = true;

        public PersonWithUser Person { get; set; } = null!;

    }
}
