using Microsoft.EntityFrameworkCore.Storage;

namespace eSistem.Dev.Estagio.Api.Interfaces.Data.Services
{
    public interface IUnityOfWork
    {
        Task<IDbContextTransaction> BeginTransactionAsync();

        Task CommitAsync();

        Task RollbackAsync();
    }
}
