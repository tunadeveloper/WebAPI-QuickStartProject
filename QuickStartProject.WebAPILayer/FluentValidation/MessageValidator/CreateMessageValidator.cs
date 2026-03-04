using FluentValidation;
using QuickStartProject.WebAPILayer.DTOs.MessageDTOs;

namespace QuickStartProject.WebAPILayer.FluentValidation.MessageValidator
{
    public class CreateMessageValidator : AbstractValidator<CreateMessageDTO>
    {
        public CreateMessageValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş olamaz.").MinimumLength(2).WithMessage("İsim en az 2 karakter olmalıdır.").MaximumLength(100).WithMessage("İsim en fazla 100 karakter olabilir.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-posta boş olamaz.").EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.").MaximumLength(100).WithMessage("E-posta en fazla 100 karakter olabilir.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş olamaz.").MinimumLength(5).WithMessage("Konu en az 5 karakter olmalıdır.").MaximumLength(200).WithMessage("Konu en fazla 200 karakter olabilir.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Mesaj içeriği boş olamaz.").MinimumLength(10).WithMessage("Mesaj en az 10 karakter olmalıdır.").MaximumLength(2000).WithMessage("Mesaj en fazla 2000 karakter olabilir.");
        }
    }
}
