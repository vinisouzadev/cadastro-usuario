using eSistem.Dev.Estagio.Api.Data;
using eSistem.Dev.Estagio.Api.Interfaces.Data.Services;
using Microsoft.EntityFrameworkCore.Storage;

namespace eSistem.Dev.Estagio.Api.Services
{
    public class UnityOfWork(ApplicationDbContext context) : IUnityOfWork
    {
        private readonly ApplicationDbContext _context = context;

        private IDbContextTransaction? _transaction;

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (!IsTransactionNull())
                throw new InvalidOperationException("Já existe uma transação ativa");

            _transaction = await _context.Database.BeginTransactionAsync();

            return _transaction;
        }

        public async Task CommitAsync()
        {
            if (IsTransactionNull())
                throw new InvalidOperationException("Não existe uma transação ativa");
             await GerarCommitAsync();
        }

        public async Task RollbackAsync()
        {
            if (IsTransactionNull())
                throw new InvalidOperationException("Não existe uma transação ativa");

            await GerarRollbackAsync();
        }

        private bool IsTransactionNull()
            => _transaction is null;

        private async Task GerarCommitAsync()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                TransactionDispose();
            }
        }
        
        private async Task GerarRollbackAsync()
        {
            try
            {
                await _transaction!.RollbackAsync();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                TransactionDispose();
            }
        }

        private void TransactionDispose()
        {
            _transaction?.Dispose();
            _transaction = null;
        }
    }
}
