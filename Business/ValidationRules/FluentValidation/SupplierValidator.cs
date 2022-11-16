using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class SupplierValidator : AbstractValidator<Supplier>
    {
        public SupplierValidator()
        {
            RuleFor(e => e.SupplierName).NotEmpty().WithMessage("Tedarikçi adı boş olamaz.");
            RuleFor(c => c.Email).NotEmpty().WithMessage("Email alanı boş olamaz.");
            RuleFor(c => c.Email).EmailAddress().WithMessage("Geçerli bir email adresi değil.");
        }
    }

}
