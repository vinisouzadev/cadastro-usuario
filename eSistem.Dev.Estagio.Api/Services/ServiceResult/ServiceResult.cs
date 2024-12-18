using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata.Ecma335;

namespace eSistem.Dev.Estagio.Api.Services.ServiceResult
{
    public class ServiceResult<T>(bool success, IList<string> errorMessages = null, T? data = default)
    {
        private IList<string> Errors { get; set; } = errorMessages ?? [];

        private bool Success { get; set; } = success;

        private T? Data { get; set; } = data;

        public void AddError(string errorMessage)
        {
            Errors.Add(errorMessage);
        }

        public void AddErrorsList(IEnumerable<string> errors)
        {
            foreach(var error in errors)
                AddError(error);
        }

        public void AddErrorsList(IEnumerable<IdentityError> errors)
        {
            foreach (var error in errors)
                AddError(error.Description);
        }

        public IList<string> GetErrors() => Errors;

        public T? GetData() => Data;

        public bool IsSuccess() => Success;
    }

}
