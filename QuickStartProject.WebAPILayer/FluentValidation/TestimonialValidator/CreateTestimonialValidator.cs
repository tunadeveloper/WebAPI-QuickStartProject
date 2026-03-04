using FluentValidation;
using QuickStartProject.WebAPILayer.DTOs.TestimonialDTOs;

namespace QuickStartProject.WebAPILayer.FluentValidation.TestimonialValidator
{
    public class CreateTestimonialValidator : AbstractValidator<CreateTestimonialDTO>
    {
        public CreateTestimonialValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş olamaz.").MinimumLength(2).WithMessage("İsim en az 2 karakter olmalıdır.").MaximumLength(100).WithMessage("İsim en fazla 100 karakter olabilir.");
            RuleFor(x => x.Role).NotEmpty().WithMessage("Rol boş olamaz.").MinimumLength(2).WithMessage("Rol en az 2 karakter olmalıdır.").MaximumLength(100).WithMessage("Rol en fazla 100 karakter olabilir.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel URL boş olamaz.").MinimumLength(5).WithMessage("Görsel URL en az 5 karakter olmalıdır.").MaximumLength(500).WithMessage("Görsel URL en fazla 500 karakter olabilir.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik boş olamaz.").MinimumLength(10).WithMessage("İçerik en az 10 karakter olmalıdır.").MaximumLength(1000).WithMessage("İçerik en fazla 1000 karakter olabilir.");
        }
    }
}
