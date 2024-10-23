namespace eSistem.Dev.Estagio.Api.Services
{
    public static class GenericServices
    {   
        /// <summary>
        /// Verifica se o texto possui algum espaço, se está vazio ou nulo e retorna true se a resposta
        /// for verdadeira em qualquer um destes casos
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsNullOrEmptyOrContainsSpace(string? text)
        {
            if (string.IsNullOrEmpty(text))
                return true;
            else if (text.Contains(" "))
                return true;
            
            return false;
        }

        /// <summary>
        /// Verifica dois textos, validando se possuem algum espaços em cada um individualmente, se estão
        /// vazios ou nulos e se alguma validação for true para qualquer um deles, retorna true
        /// </summary>
        /// <param name="text1"></param>
        /// <param name="text2"></param>
        /// <returns></returns>
        public static bool IsNullOrEmptyOrContainsSpace(string text1, string text2)
        {
            if (text1.Contains(" ") || string.IsNullOrEmpty(text1) ||
                text2.Contains(" ") || string.IsNullOrEmpty(text2))
                return true;

            return false;
        }
    }
}
