using eSistem.Dev.Estagio.Api.Interfaces.IServiceResult;

namespace eSistem.Dev.Estagio.Api.Services.ServiceResult
{
    public class ServiceResultFactory<T> : IServiceResultFactory<T>
    {
        public ServiceResult<T> Failure(IList<string> message = null)
            => new(false, message);

        public ServiceResult<T> Success(T data)
            => new(true, data: data);
    }
}
