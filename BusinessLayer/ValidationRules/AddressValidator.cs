using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            //Map Kuralları
            RuleFor(x => x.MapInfo).NotEmpty().WithMessage("Başlık Kısmı Boş Bırakılamaz!");
            RuleFor(x => x.MapInfo).MinimumLength(5).WithMessage("Başlık Minimum 5 Karakter Olmalıdır!");
            RuleFor(x => x.MapInfo).MaximumLength(20).WithMessage("Başlık Maximum 20 Karakter Olmalıdır!");

            //Açıklama Kuralları
            RuleFor(x => x.Description1).NotEmpty().WithMessage("Açıklama 1 Boş Bırakılamazz!!");

        }
    }
}
