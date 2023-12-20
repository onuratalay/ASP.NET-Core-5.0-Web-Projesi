using System.ComponentModel.DataAnnotations;

namespace CoreProje.Areas.User.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen geçerli bir isim giriniz!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen geçerli bir soyisim giriniz!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen geçerli bir kullanıcı adı giriniz!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen geçerli bir şifre giriniz!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi tekrar giriniz!")]
        [Compare("Password", ErrorMessage = "Şifreleriniz birbiri ile uyumlu değil!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Lütfen geçerli bir mail adresi giriniz!")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen geçerli bir resim yolu giriniz!")]
        public string ImageUrl { get; set; }
    }
}
