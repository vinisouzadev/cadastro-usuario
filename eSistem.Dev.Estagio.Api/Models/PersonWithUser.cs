using eSistem.Dev.Estagio.Api.Models.Identity;
using eSistem.Dev.Estagio.Core.Models;
using System.Text.Json.Serialization;

namespace eSistem.Dev.Estagio.Api.Models
{
    public class PersonWithUser : Person
    {
        [JsonIgnore]
        public Usuario Usuario { get; set; }
    }
}
