using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ordering.Domain.AggregateModel.BuyerAggregate
{
    public interface IBuyerRepository
    {
        Task InsertAsync(Buyer buyer);
        Task UpdateAsync(Buyer buyer);
        Task DeleteAsync(Buyer buyer);
        Task<Buyer> GetBuyerById(Guid id);
        Task<Buyer> GetBuyer(Expression<Func<Buyer, bool>> predicate);
        Task<IEnumerable<Buyer>> GetBuyers();
    }
}
