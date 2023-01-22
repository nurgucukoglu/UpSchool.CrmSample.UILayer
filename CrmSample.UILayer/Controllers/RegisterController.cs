using CrmSample.EntityLayer.Concrete;
using CrmSample.UILayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using CrmSample.BusinessLayer.Abstract;

namespace CrmSample.UILayer.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager; //yeni kayıt işlemi için önce usermanager sınıfına gitmek gerekli. sonra usermanager için DI uygulamak gerekli. (class.a Gen Cons)

        public RegisterController(UserManager<AppUser> userManager) //DI
        {
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult EmailConfirmed()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> EmailConfirmed(AppUser appUser)
        {
            var user = await _userManager.FindByEmailAsync(appUser.Email);
            if (user.EmailConfirmedControlCode == appUser.EmailConfirmedControlCode)
            {
                user.EmailConfirmed = true;

                var result = await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }
            return View();
        }



        public void SendEmail(string emailAddress, string emailcode)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "testpostasi4744@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom); //Maili gönderen

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", emailAddress);
            mimeMessage.To.Add(mailboxAddressTo); //mail gönderilecek kişi

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = emailcode;
            mimeMessage.Body = bodyBuilder.ToMessageBody(); //Mail içeriği

            mimeMessage.Subject = "Üyelik Kaydı"; //Mail konusu

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("testpostasi4744@gmail.com", "eamxczcwmbxtpwqq");
            client.Send(mimeMessage);
            client.Disconnect(true);
        }

        //testpostasi4744
        //eamxczcwmbxtpwqq



        //MODELLE ÇALIŞMA KISIMLARI (appuser.ı fluent vali.ye bağlamadığımız için hata mesajları almıyorduk.hata mesajları için modelle çalışcaz.
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignUpModel p) //modelle çalışıcağımız için modeli ekledik ve bir p oluşturduk. Ve sonra atamaları yapmak gerekli:
        {

            Random rnd = new Random();
            string code = rnd.Next(10000, 999999).ToString(); //confirm için gelecek 6 haneli kod

            if (ModelState.IsValid) //eğer model gereliyse: aşağıdaakileri yap. bunu şu yüzden yazdık. kaytıt olurken index2.de asp-vali-for ve required ve span boş geçmeden kaydetememeyi önleyemedi. Bu Model kontrolünü en başta ayazmak zorundayız.
             //ve buna ele yzmaya gerek yok.sadece index tarafında span asp-vali-for.ları görsek yeterli.
            {
                AppUser appUser = new AppUser() //appuser.ı newledik. ve parametreden gelen değerleri(signupmodel) appuser.a atadık.
                {
                    UserName = p.Username,
                    Name = p.Name,
                    SurName = p.SurName,
                    Email = p.Email,
                    PhoneNumber = p.Phonenumber,
                    EmailConfirmedControlCode = code
                };


                if (p.Password == p.ConfirmPassword) ///eğer şifreler uyumluysa:
                {
                    var result = await _userManager.CreateAsync(appUser, p.Password);  //yeni bir netuser ekleme metodu:createasync //parametresine appuser gönderdik çünkü p.den gelen değerleri appuser.a atadık.(o bağlı db.ye)


                    if (result.Succeeded) //eğer result başarılı olursa
                    {

                        SendEmail(p.Email, code);
                        return RedirectToAction("EmailConfirmed", "Register");
                    }

                    else  //validasyonları sağlamıyorsa
                    {
                        foreach (var item in result.Errors) //hata döndürcek. Result.tan gelen hataları okucak burası
                        {
                            ModelState.AddModelError("", item.Description); //(item.Description) hatanın detayını göstericek.
                        }
                    }

                }

                else //şifreler uyuşmuyorsa
                {
                    ModelState.AddModelError("", "şifreler uyuşmuyor");
                }
            }
            return View();
        }








    }
}
