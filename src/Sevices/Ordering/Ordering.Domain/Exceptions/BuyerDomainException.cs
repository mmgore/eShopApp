using System;

namespace Ordering.Domain.Exceptions
{
    public class BuyerDomainException: Exception
    {
        public BuyerDomainException()
        {
        }

        public BuyerDomainException(string message)
            : base(message)
        {
        }

        public BuyerDomainException(string message, Exception exception)
            : base(message, exception)
        {
        }
    }
}
