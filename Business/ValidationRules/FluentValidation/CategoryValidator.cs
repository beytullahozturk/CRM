using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(p => p.CategoryName).NotEmpty().WithMessage("Kategori adı boş olamaz.");
            RuleFor(p => p.CategoryName).MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır.");
            RuleFor(p => p.CategoryName).MaximumLength(50).WithMessage("Kategori adı en çok 50 karakter olmalıdır.");
        }
    }
}
