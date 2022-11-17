using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class OrderDetailValidator : AbstractValidator<OrderDetail>
    {
        public OrderDetailValidator()
        {
            RuleFor(p => p.Quantity).NotEmpty().WithMessage("Miktar alanı boş olamaz.");
        }
    }

}
