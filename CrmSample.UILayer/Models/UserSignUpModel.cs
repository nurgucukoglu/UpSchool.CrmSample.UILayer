using System.ComponentModel.DataAnnotations;

namespace CrmSample.UILayer.Models
{
    public class UserSignUpModel
    {
        [Required(ErrorMessage = "lütfen kullanıcı adını giriniz")]
        public string Username { get; set; }

        [Required(ErrorMessage = "lütfen adınızı giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "lütfen soyadınızı giriniz")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "lütfen mailinizi giriniz")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir mail giriniz")] //email formatı kontrolü
        public string Email { get; set; }

        [Required(ErrorMessage = "lütfen telefonunuzu giriniz")]
        public string Phonenumber { get; set; }

        [Required(ErrorMessage = "lütfen şifrenizi giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "lütfen şifreyi tekrar giriniz")]
        [Compare("Password", ErrorMessage = "şifreler uyuşmuyor lütfen tekrar deneyin")] //confirm olark kullanabilmek için compare yazmak gerekli.
        public string ConfirmPassword { get; set; }
    }
}
