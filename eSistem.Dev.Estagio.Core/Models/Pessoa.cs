using eSistem.Dev.Estagio.Core.Enums;

namespace eSistem.Dev.Estagio.Core.Models
{
    public class Pessoa
    {
        public int Id { get; set; }

        public string NomeRazaoSocial { get; set; } = string.Empty;

        public ETipo Tipo { get; set; }

        public string CpfCnpj { get; set; } = string.Empty;

        public DateTime Cadastro { get; set; } = DateTime.UtcNow;

        public bool Ativo { get; set; } = true;

    }
}
