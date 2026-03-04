using FluentValidation;
using QuickStartProject.WebAPILayer.DTOs.FaqDTOs;

namespace QuickStartProject.WebAPILayer.FluentValidation.FaqValidator
{
    public class CreateFaqValidator : AbstractValidator<CreateFaqDTO>
    {
        public CreateFaqValidator()
        {
            RuleFor(x => x.Question).NotEmpty().WithMessage("Soru boş olamaz.").MinimumLength(10).WithMessage("Soru en az 10 karakter olmalıdır.").MaximumLength(500).WithMessage("Soru en fazla 500 karakter olabilir.");
            RuleFor(x => x.Answer).NotEmpty().WithMessage("Cevap boş olamaz.").MinimumLength(10).WithMessage("Cevap en az 10 karakter olmalıdır.").MaximumLength(2000).WithMessage("Cevap en fazla 2000 karakter olabilir.");
        }
    }
}
