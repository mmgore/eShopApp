using Ordering.Domain.SeedWork;
using System;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool _disposed = false;

        private readonly OrderingContext _orderDbContext;
        public UnitOfWork(OrderingContext orderDbContext)
        {
            _orderDbContext = orderDbContext ?? throw new ArgumentNullException(nameof(orderDbContext));
        }

        public async Task SaveChangesAsync()
        {
            await _orderDbContext.SaveChangesAsync();
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _orderDbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
