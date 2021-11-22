using Ordering.Application.Interfaces;
using Ordering.Domain.AggregateModel.OrderAggregate;
using System.Threading.Tasks;

namespace Ordering.Application.Utilities
{
    public class SendEmailHandler : IMailSender
    {
        public async Task SendMail(Order order)
        {
        }
    }
}
