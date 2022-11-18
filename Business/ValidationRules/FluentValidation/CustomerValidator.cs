using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Email).NotEmpty().WithMessage("Email boş olamaz.");
            RuleFor(c => c.Email).EmailAddress().WithMessage("Geçerli bir email adresi değil.");
        }
    }




}
