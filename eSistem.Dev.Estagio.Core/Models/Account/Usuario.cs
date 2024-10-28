namespace eSistem.Dev.Estagio.Core.Models.Account
{
    public class Usuario
    {
        public string UserName { get; set; } = string.Empty;

        public Dictionary<string, string> Claims { get; set; } = [];

        public Pessoa Pessoa { get; set; } = new();
    }
}
