using FluentValidation;
using QuickStartProject.WebAPILayer.DTOs.ServiceDTOs;

namespace QuickStartProject.WebAPILayer.FluentValidation.ServiceValidator
{
    public class UpdateServiceValidator : AbstractValidator<UpdateServiceDTO>
    {
        public UpdateServiceValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Geçerli bir Id gereklidir.");
            RuleFor(x => x.Icon).NotEmpty().WithMessage("İkon boş olamaz.").MinimumLength(2).WithMessage("İkon en az 2 karakter olmalıdır.").MaximumLength(100).WithMessage("İkon en fazla 100 karakter olabilir.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş olamaz.").MinimumLength(2).WithMessage("Başlık en az 2 karakter olmalıdır.").MaximumLength(200).WithMessage("Başlık en fazla 200 karakter olabilir.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş olamaz.").MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.").MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");
        }
    }
}
