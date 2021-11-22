using Ordering.Domain.AggregateModel.OrderAggregate;
using System.Threading.Tasks;

namespace Ordering.Application.Interfaces
{
    public interface IMailSender
    {
        Task SendMail(Order order);
    }
}
