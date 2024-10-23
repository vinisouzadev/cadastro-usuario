using eSistem.Dev.Estagio.Api.Models.Identity;
using eSistem.Dev.Estagio.Core.Models;
using System.Text.Json.Serialization;

namespace eSistem.Dev.Estagio.Api.Models
{
    public class PessoaWithUser : Pessoa
    {
        [JsonIgnore]
        public Usuario? User { get; set; }
    }
}
