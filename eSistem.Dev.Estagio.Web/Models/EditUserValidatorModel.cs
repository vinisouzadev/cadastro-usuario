namespace eSistem.Dev.Estagio.Web.Models
{
    public class EditUserValidatorModel
    {
        public bool IsUserNameInvalid => UserNameError.Count > 0;

        public List<string> UserNameError { get; set; } = [];

        public bool IsNomeRazaoSocialInvalid => NomeRazaoSocialError.Count > 0; 

        public List<string> NomeRazaoSocialError { get; set; } = [];

        public bool IsValid()
        {
            if (IsUserNameInvalid
                || IsNomeRazaoSocialInvalid)
                return false;

            return true;
        }
    }
}