using Microsoft.AspNetCore.Identity;

namespace CrmSample.UILayer.Models
    // IDENTITY.DEN DEFAULT GELEN PASSWORD HATA MESAJLARINI TÜRK.ELEŞTİRMEK İÇİN AÇILAN MODEL// Identity için özelleştirilmiş doğrulama modeli
{
    public class CustomIdentityValidator:IdentityErrorDescriber //describer sınıfına bağlı olarak ilgili hataları özel düzenlememize yarar.
     //eğer bir şeyi yine kullanıcam ama kendi istediğim formatta ise OVERRİDE kullanmalıyım. 
    {
        public override IdentityError PasswordTooShort(int length) //ıdentityerrror yazdıktqan sonra ctrl space ile metot geldi.içi sildik return ekledik ve hata code.u aynı gelsin istedim. hata açıklamasına istediğim şeyi yazdım.
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Şifre en az {length} karakter olmalıdır"
            };
        }
        public override IdentityError PasswordRequiresLower()//küçük harf zorunluluğu
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = "Lütfen en az 1 tane küçük harf giriniz"
            };
        }
        public override IdentityError PasswordRequiresUpper() //büyük harf zorunluluğu 
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = "Lütfen en az 1 tane büyük harf giriniz"
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresDigit",
                Description = "Lütfen en az 1 tane sayı girişi yapın"
            };
        }
        public override IdentityError DuplicateEmail(string email) //eğer db.de bu mail zaten varsa:
        {
            return new IdentityError()
            {
                Code = "DuplicateEmail",
                Description = $"ilgili mail adresi: {email} zaten sistemde mevcut, lütfen farklı bir mail adresi ile kayıt olun"
            };
        }
        public override IdentityError DuplicateUserName(string userName) //username için de aynısı varsa sistemde kabul etmesin.
        {
            return new IdentityError()
            {
                Code = "DuplicateUserName",
                Description = $"ilgili kullanıcı adı: {userName} zaten sistemde mevcut, lütfen farklı bir kullanıcı adı ile kayıt olun"
            };
        }
    }
}
