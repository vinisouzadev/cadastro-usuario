namespace eSistem.Dev.Estagio.Web.Models
{
    public class LoginValidatorModel
    {
        public bool IsUserNameInvalid => UserNameError.Count > 0;

        public List<string> UserNameError { get; set; } = [];

        public bool IsPasswordInvalid => PasswordError.Count > 0;

        public List<string> PasswordError { get; set; } = [];

        public bool IsValid()
        {
            if (IsUserNameInvalid
                || IsPasswordInvalid)
                return false;

            return true;
        }
    }
}