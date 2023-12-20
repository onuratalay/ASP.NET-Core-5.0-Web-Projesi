using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreProje.Areas.User.Models
{
    public class UserLoginViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen geçerli bir kullanıcı adı giriniz!")]
        public string Username { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen geçerli bir şifre giriniz!")]
        public string Password { get; set; }
    }
}
