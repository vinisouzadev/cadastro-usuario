using eSistem.Dev.Estagio.Api.Services.ServiceResult;

namespace eSistem.Dev.Estagio.Api.Interfaces.IServiceResult
{
    public interface IServiceResultFactory<T>
    {
        ServiceResult<T> Success(T data);

        ServiceResult<T> Failure(IList<string> message);
    }
}
