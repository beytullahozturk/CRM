using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.FirstName).NotEmpty().WithMessage("Personel adı boş olamaz.");
            RuleFor(e => e.LastName).NotEmpty().WithMessage("Personel soyadı boş olamaz.");
            RuleFor(c => c.Email).NotEmpty().WithMessage("Email alanı boş olamaz.");
            RuleFor(c => c.Email).EmailAddress().WithMessage("Geçerli bir email adresi değil.");
        }
    }

}
