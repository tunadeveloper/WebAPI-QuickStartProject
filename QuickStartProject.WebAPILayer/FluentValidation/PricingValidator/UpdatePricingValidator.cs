using FluentValidation;
using QuickStartProject.WebAPILayer.DTOs.PricingDTOs;

namespace QuickStartProject.WebAPILayer.FluentValidation.PricingValidator
{
    public class UpdatePricingValidator : AbstractValidator<UpdatePricingDTO>
    {
        public UpdatePricingValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Geçerli bir Id gereklidir.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Plan adı boş olamaz.").MinimumLength(2).WithMessage("Plan adı en az 2 karakter olmalıdır.").MaximumLength(100).WithMessage("Plan adı en fazla 100 karakter olabilir.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş olamaz.").MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.").MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat boş olamaz.").MinimumLength(1).WithMessage("Fiyat girilmelidir.").MaximumLength(20).WithMessage("Fiyat en fazla 20 karakter olabilir.");
            RuleFor(x => x.Period).NotEmpty().WithMessage("Dönem boş olamaz.").MinimumLength(2).WithMessage("Dönem en az 2 karakter olmalıdır.").MaximumLength(50).WithMessage("Dönem en fazla 50 karakter olabilir.");
            RuleFor(x => x.Features).NotNull().WithMessage("Özellikler listesi boş olamaz.");
        }
    }
}
