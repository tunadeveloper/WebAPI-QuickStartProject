using FluentValidation;
using QuickStartProject.WebAPILayer.DTOs.AboutDTOs;

namespace QuickStartProject.WebAPILayer.FluentValidation.AboutValidator
{
    public class UpdateAboutValidator : AbstractValidator<UpdateAboutDTO>
    {
        public UpdateAboutValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Geçerli bir Id gereklidir.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş olamaz.").MinimumLength(2).WithMessage("Başlık en az 2 karakter olmalıdır.").MaximumLength(200).WithMessage("Başlık en fazla 200 karakter olabilir.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş olamaz.").MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.").MaximumLength(2000).WithMessage("Açıklama en fazla 2000 karakter olabilir.");
            RuleFor(x => x.Images).NotNull().WithMessage("Görseller listesi boş olamaz.").Must(x => x.Count >= 1).WithMessage("En az 1 görsel eklenmelidir.").Must(x => x.Count <= 10).WithMessage("En fazla 10 görsel eklenebilir.");
        }
    }
}
