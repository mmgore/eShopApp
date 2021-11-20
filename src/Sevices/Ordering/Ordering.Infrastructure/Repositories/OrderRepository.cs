using Ordering.Domain.AggregateModel.OrderAggregate;
using Ordering.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IRepository<Order> _repository;
        public OrderRepository(IRepository<Order> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task DeleteAsync(Order order)
        {
            await _repository.DeleteAsync(order);
        }

        public async Task<Order> GetOrder(Expression<Func<Order, bool>> predicate)
            => await _repository.GetAsync(predicate);

        public async Task<Order> GetOrderById(Guid id)
            => await _repository.GetAsync(id);

        public async Task<IEnumerable<Order>> GetOrders()
            => await _repository.GetAllAsync();

        public async Task InsertAsync(Order order)
        {
            await _repository.InsertAsync(order);
        }

        public async Task UpdateAsync(Order order)
        {
            await _repository.UpdateAsync(order);
        }
    }
}
