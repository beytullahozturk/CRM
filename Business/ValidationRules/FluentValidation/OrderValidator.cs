using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(p => p.CustomerId).NotEmpty().WithMessage("Müşteri alanı boş olamaz.");
            RuleFor(p => p.EmployeeId).NotEmpty().WithMessage("Personel alanı boş olamaz.");
        }
    }
}
