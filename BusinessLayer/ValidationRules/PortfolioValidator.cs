using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class PortfolioValidator : AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Proje adı boş geçilemez!");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Küçük görsel alanı boş geçilemez!");
            RuleFor(x => x.ImageUrl2).NotEmpty().WithMessage("Büyük görsel alanı boş geçilemez!");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat bilgisi boş geçilemez!");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Değer alanı boş geçilemez!");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Proje adı en az 5 karakterden oluşmak zorundadır!");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Proje adı en fazla 30 karakterden oluşmak zorundadır!");
        }
    }
}
