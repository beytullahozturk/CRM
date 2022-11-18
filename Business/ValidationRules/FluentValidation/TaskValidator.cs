using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class TaskValidator : AbstractValidator<Task>
    {
        public TaskValidator()
        {
            RuleFor(e => e.Title).NotEmpty().WithMessage("Başlık boş olamaz.");
            RuleFor(e => e.Description).NotEmpty().WithMessage("Açıklama boş olamaz.");
        }
    }


}
