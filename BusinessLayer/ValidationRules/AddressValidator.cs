using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            //Harita Bilgisi Kuralları
            RuleFor(x => x.MapInfo).NotEmpty().WithMessage("Harita Bilgisi Boş Bırakılamaz!");
            RuleFor(x => x.MapInfo).MinimumLength(5).WithMessage("Harita Bilgisi Minimum 5 Karakter Olmalıdır!");
            RuleFor(x => x.MapInfo).MaximumLength(20).WithMessage("Harita Bilgisi Maximum 20 Karakter Olmalıdır!");

            //Açıklama Kuralları
            RuleFor(x => x.Description1).NotEmpty().WithMessage("Açıklama 1 Boş Bırakılamazz!");
            RuleFor(x => x.Description2).NotEmpty().WithMessage("Açıklama 2 Boş Bırakılamazz!");
            RuleFor(x => x.Description3).NotEmpty().WithMessage("Açıklama 3 Boş Bırakılamazz!");
            RuleFor(x => x.Description4).NotEmpty().WithMessage("Açıklama 4 Boş Bırakılamazz!");

        }
    }
}
