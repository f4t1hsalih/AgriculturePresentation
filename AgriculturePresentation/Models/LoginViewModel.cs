using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Kullanıcı Adını Girin!")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Şifreyi Girin!")]
        public string password { get; set; }
    }
}
