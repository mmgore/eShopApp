using Ordering.Domain.AggregateModel.BuyerAggregate;
using Ordering.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories
{
    public class BuyerRepository : IBuyerRepository
    {
        private readonly IRepository<Buyer> _repository;
        public BuyerRepository(IRepository<Buyer> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task DeleteAsync(Buyer buyer)
        {
            await _repository.DeleteAsync(buyer);
        }

        public async Task<Buyer> GetBuyer(Expression<Func<Buyer, bool>> predicate)
            => await _repository.GetAsync(predicate);

        public async Task<Buyer> GetBuyerById(Guid id)
            => await _repository.GetAsync(id);

        public async Task<IEnumerable<Buyer>> GetBuyers()
            => await _repository.GetAllAsync();

        public async Task InsertAsync(Buyer buyer)
        {
            await _repository.InsertAsync(buyer);
        }

        public async Task UpdateAsync(Buyer buyer)
        {
            await _repository.UpdateAsync(buyer);
        }
    }
}
