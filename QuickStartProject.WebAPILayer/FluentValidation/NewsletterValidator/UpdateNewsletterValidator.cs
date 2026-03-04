using FluentValidation;
using QuickStartProject.WebAPILayer.DTOs.NewsletterDTOs;

namespace QuickStartProject.WebAPILayer.FluentValidation.NewsletterValidator
{
    public class UpdateNewsletterValidator : AbstractValidator<UpdateNewsletterDTO>
    {
        public UpdateNewsletterValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Geçerli bir Id gereklidir.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-posta boş olamaz.").EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.").MinimumLength(5).WithMessage("E-posta en az 5 karakter olmalıdır.").MaximumLength(100).WithMessage("E-posta en fazla 100 karakter olabilir.");
        }
    }
}
