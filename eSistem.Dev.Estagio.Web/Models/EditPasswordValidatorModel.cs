namespace eSistem.Dev.Estagio.Web.Models
{
    public class EditPasswordValidatorModel
    {
        public bool IsCurrentPasswordInvalid => CurrentPasswordError.Count > 0;

        public List<string> CurrentPasswordError { get; set; } = [];

        public bool IsPasswordInvalid => PasswordError.Count > 0;

        public List<string> PasswordError { get; set; } = [];

        public bool IsConfirmPasswordInvalid => ConfirmPasswordError.Count > 0;

        public List<string> ConfirmPasswordError { get; set; } = [];

        public bool IsValid()
        {
            if (IsCurrentPasswordInvalid
                || IsPasswordInvalid
                || IsConfirmPasswordInvalid)
                return false;

            return true;
        }
    }
}