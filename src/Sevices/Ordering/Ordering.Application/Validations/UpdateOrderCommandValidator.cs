using FluentValidation;
using Ordering.Application.Commads.UpdateOrder;

namespace Ordering.Application.Validations
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(r => r.EmailAddress).NotNull()
                .WithMessage("Email Address is required!");

            RuleFor(r => r.Country).NotNull();

            RuleFor(r => r.Username).NotNull();

            RuleFor(r => r.TotalPrice).NotNull()
                .GreaterThan(0);

            RuleFor(r => r.ZipCode).NotNull();
        }
    }
}
