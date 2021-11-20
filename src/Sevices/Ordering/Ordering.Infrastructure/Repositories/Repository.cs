using Microsoft.EntityFrameworkCore;
using Ordering.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly OrderingContext _context;
        private DbSet<T> _dbSet;
        public Repository(OrderingContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetAsync(id);
            _dbSet.Remove(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);
            _dbSet.Remove(entity);
            await Task.FromResult(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
            => await _dbSet.Where(predicate).ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync()
            => await _dbSet.ToListAsync();

        public async Task<T> GetAsync(Guid id)
            => await _dbSet.FindAsync(id);

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
            => await _dbSet.Where(predicate).FirstOrDefaultAsync();

        public async Task InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public IQueryable<T> Queryable() => _dbSet;

        public IQueryable<T> Queryable(Expression<Func<T, bool>> predicate)
            => _dbSet.Where(predicate);

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await Task.FromResult(entity);
        }
    }
}
