using eSistem.Dev.Estagio.Api.Models;
using eSistem.Dev.Estagio.Api.Models.Identity;
using eSistem.Dev.Estagio.Api.Services.ServiceResult;

namespace eSistem.Dev.Estagio.Api.Interfaces.IServiceResult
{
    public interface IServiceResultManager
    {
        ServiceResultFactory<Usuario?> UserServiceResult { get; }

        ServiceResultFactory<string> VoidServiceResult { get; }

        ServiceResultFactory<PersonWithUser> PersonServiceResult { get; }
    }
}