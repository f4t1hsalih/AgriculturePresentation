using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen Bir Kullanıcı Adı Giriniz!")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Lütfen Bir Mail Giriniz!")]
        public string mail { get; set; }

        [Required(ErrorMessage = "Lütfen Şifreyi Giriniz!")]
        public string password { get; set; }

        [Required(ErrorMessage = "Lütfen Şifreyi Tekrar Giriniz!")]
        [Compare("password", ErrorMessage = "Şifreler Uyumlu değil, kontrol edin")]
        public string passwordConfirm { get; set; }

    }
}
