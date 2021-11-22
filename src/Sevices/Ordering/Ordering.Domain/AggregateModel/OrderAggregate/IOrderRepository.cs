using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ordering.Domain.AggregateModel.OrderAggregate
{
    public interface IOrderRepository
    {
        Task InsertAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(Order order);
        Task<Order> GetOrderById(Guid id);
        Task<Order> GetOrder(Expression<Func<Order, bool>> predicate);
        Task<IEnumerable<Order>> GetOrders();
        Task<IEnumerable<Order>> GetOrdersByUserName(string username);
    }
}
