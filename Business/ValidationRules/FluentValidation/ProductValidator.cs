using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün adı boş olamaz.");
            RuleFor(p => p.ProductName).MinimumLength(2).WithMessage("ürün adı en az 2 karakter olmalıdır.");
            RuleFor(p => p.ProductName).MaximumLength(50).WithMessage("ürün adı en çok 50 karakter olmalıdır.");
            RuleFor(p => p.UnitPrice).NotEmpty().WithMessage("Birim fiyat boş olamaz.");
            RuleFor(p => p.UnitPrice).GreaterThan(0).WithMessage("Birim fiyat sıfırdan büyük olmalıdır.");
        }
    }
}
