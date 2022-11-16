using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.CustomerName).NotEmpty().WithMessage("Müşteri adı boş olamaz.");
            RuleFor(c => c.Email).NotEmpty().WithMessage("Email alanı boş olamaz.");
            RuleFor(c => c.Email).EmailAddress().WithMessage("Geçerli bir email adresi değil.");
        }
    }




}
