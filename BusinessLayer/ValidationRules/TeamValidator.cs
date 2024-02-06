using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    // TeamValidator, Team (Takım) sınıfının doğrulama kurallarını tanımlayan bir FluentValidation sınıfıdır.
    public class TeamValidator : AbstractValidator<Team>
    {
        // Kurucu metod: FluentValidation kuralları bu metod içinde tanımlanır.
        public TeamValidator()
        {
            // Name özelliği için kural tanımları:

            // Boş olmama kuralı: İsim özelliği boş olmamalıdır. 
            RuleFor(x => x.Name).NotEmpty().WithMessage("Personel İsmi Boş Geçilemez");

            // Uzunluk kontrolü: İsim en az 3 karakter ve en fazla 30 karakter içermelidir.
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Personel İsmi Minumum 3 Karekter İçermelidir");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Personel İsmi Maksimum 30 Karekter İçermelidir");

            // Title özelliği için kural tanımları:

            // Boş olmama kuralı: Görev (Title) kısmı boş olmamalıdır.
            RuleFor(x => x.Title).NotEmpty().WithMessage("Görev Kısmı Boş Geçilemez");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("Görev Kısmı Minumum 3 Karekter İçermelidir");

        }
    }
}
