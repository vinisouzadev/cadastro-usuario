using eSistem.Dev.Estagio.Api.Interfaces.IServiceResult;
using eSistem.Dev.Estagio.Api.Models;
using eSistem.Dev.Estagio.Api.Models.Identity;

namespace eSistem.Dev.Estagio.Api.Services.ServiceResult
{
    public class ServiceResultManager : IServiceResultManager
    {
        public ServiceResultFactory<Usuario?> UserServiceResult => new();

        public ServiceResultFactory<string> VoidServiceResult => new();

        public ServiceResultFactory<PersonWithUser> PersonServiceResult => new();

    }
}
