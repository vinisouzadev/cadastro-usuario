namespace eSistem.Dev.Estagio.Web.Models
{
    public class RegisterUserValidatorModel
    {
        public bool IsNomeRazaoSocialInvalid => NomeRazaoSocialError.Count > 0;

        public List<string> NomeRazaoSocialError { get; set; } = [];

        public bool IsCpfCnpjInvalid => CpfCnpjError.Count > 0;

        public List<string> CpfCnpjError { get; set; } = [];

        public bool IsUserNameInvalid => UserNameError.Count > 0;

        public List<string> UserNameError { get; set; } = [];

        public bool IsPasswordInvalid => PasswordError.Count > 0;

        public List<string> PasswordError { get; set; } = [];

        public bool IsConfirmPasswordInvalid => ConfirmPasswordError.Count > 0;

        public List<string> ConfirmPasswordError { get; set; } = [];

        public bool IsValid()
        {
            if (IsNomeRazaoSocialInvalid
                || IsCpfCnpjInvalid
                || IsUserNameInvalid
                || IsPasswordInvalid
                || IsConfirmPasswordInvalid)
                return false;

            return true;
        }
    }
}
