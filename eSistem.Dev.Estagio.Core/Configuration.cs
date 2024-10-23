using System.Text.RegularExpressions;

namespace eSistem.Dev.Estagio.Core
{
    public static class Configuration
    {
        public const int DefaultStatusCode = 200;

        public static string BackendUrl { get; set; } = string.Empty;

        public static string FrontendUrl { get; set; } = string.Empty;

        public static string ConnectionString { get; set; } = string.Empty;

        public const int DefaultPageSize = 25;

        public const int DefaultCurrentPage = 0;
        
        public static bool CpfCnpjFormatVerify(string cpfCnpj)
        {
            Regex regex = new Regex(@"^\d+$");

            return regex.IsMatch(cpfCnpj);
        }
    }
}
