using FluentValidation;
using QuickStartProject.WebAPILayer.DTOs.ContactDTOs;

namespace QuickStartProject.WebAPILayer.FluentValidation.ContactValidator
{
    public class CreateContactValidator : AbstractValidator<CreateContactDTO>
    {
        public CreateContactValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş olamaz.").MinimumLength(2).WithMessage("Başlık en az 2 karakter olmalıdır.").MaximumLength(200).WithMessage("Başlık en fazla 200 karakter olabilir.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş olamaz.").MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.").MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres boş olamaz.").MinimumLength(5).WithMessage("Adres en az 5 karakter olmalıdır.").MaximumLength(300).WithMessage("Adres en fazla 300 karakter olabilir.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon boş olamaz.").MinimumLength(10).WithMessage("Telefon en az 10 karakter olmalıdır.").MaximumLength(20).WithMessage("Telefon en fazla 20 karakter olabilir.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-posta boş olamaz.").EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.").MaximumLength(100).WithMessage("E-posta en fazla 100 karakter olabilir.");
        }
    }
}
