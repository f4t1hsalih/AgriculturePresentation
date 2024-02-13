using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ImageValidator : AbstractValidator<Image>
    {
        public ImageValidator()
        {
            //Başlık Kuralları
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Kısmı Boş Bırakılamaz!");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Başlık Minimum 5 Karakter Olmalıdır!");
            RuleFor(x => x.Title).MaximumLength(20).WithMessage("Başlık Maximum 20 Karakter Olmalıdır!");

            //Açıklama Kuralları
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Boş Bırakılamazz!!");
            RuleFor(x => x.Description).MinimumLength(10).WithMessage("Başlık Minimum 10 Karakter Olmalıdır!");
            RuleFor(x => x.Description).MaximumLength(50).WithMessage("Başlık Maximum 50 Karakter Olmalıdır!");

            //Resim Yolu Kuralları
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim Seçmeden İlerleyemezsiniz!");

        }
    }
}
