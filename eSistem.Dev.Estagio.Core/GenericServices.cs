namespace eSistem.Dev.Estagio.Core
{
    public static class GenericServices
    {
        public static bool IsNullOrEmptyOrContainsSpace(string? str1)
        {
            if (string.IsNullOrEmpty(str1))
                return true;
            if (str1.Contains(" "))
                return true;

            return false;
        }

        public static bool IsNullOrEmptyOrContainsSpace(string? str1, string? str2)
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
                return true;
            if (str1.Contains(" ") || str2.Contains(" "))
                return true;

            return false;
        }

    }
}
