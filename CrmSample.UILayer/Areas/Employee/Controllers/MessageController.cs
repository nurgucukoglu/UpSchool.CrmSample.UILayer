using CrmSample.BusinessLayer.Abstract;
using CrmSample.DataAccessLayer.Concrete;
using CrmSample.EntityLayer.Concrete;
using CrmSample.UILayer.Areas.Employee.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using MimeKit;
using System;
using System.Linq;
using System.Threading.Tasks;
using Message = CrmSample.EntityLayer.Concrete.Message;

namespace CrmSample.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class MessageController : Controller
    {
        //DI
        private readonly IMessageService _messageService;
        private readonly UserManager<AppUser> _userManager;
       
        public MessageController(IMessageService messageService, UserManager<AppUser> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }
        //

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(Message m)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name); //user.ın mailini çektik identityden
            m.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()); // tarihi getirdik
            m.SenderEmail = user.Email; //gönderen mailini aldık
            m.SenderName = user.Name + " " + user.SurName; //ad soyad
            using(var context=new Context()) //receiver maili yazınca adı gelsin diye context.i örnekleyip ad soyadını getirdik.
            {
                m.ReceiverName = context.Users.Where(x => x.Email == m.ReceiverEmail).Select(x => x.Name + "" + x.SurName).FirstOrDefault();
            }

            _messageService.TInsert(m); //MESAJI GÖNDER
            return RedirectToAction("Send Message");
        }

        //iexdzknwllkzunxw--gmailşifre

        [HttpGet]
        public async Task<IActionResult> SendEMail()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEMail(MailRequest p)
        {

            MimeMessage mimeMessage = new MimeMessage(); //m,memessage sınıfından bir nesne türettik.

            MailboxAddress mailBoxAddressFrom = new MailboxAddress("Admin", "enurgucuk@gmail.com");  //MAİLİN KİMDEN GİTTİĞİNİ GÖSTERİR.1.parametre: mail kim tarafından gönderildi.2.parametre: gönderilen mail adresi yani şifrsini aktif hale getirdiğimiz mail adresi
            mimeMessage.From.Add(mailBoxAddressFrom);  //mailin kimden gönderileceği bilgisini ekledik.


            MailboxAddress mailboxAddressTo = new MailboxAddress("User", p.ReceiverMail);  //mailin kime gönderileceğini modelden aldık.
            mimeMessage.To.Add(mailboxAddressTo);  //mesajın kime gönderileceği bilgisini ekledik


            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = p.EmailContent;//mailin içeriik kısımı
            mimeMessage.Body = bodyBuilder.ToMessageBody();//mailin içeriği
            mimeMessage.Subject = p.EmailSubject;//mailin konusu

            //mail gönderme protokolü
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false); //tr için port 587
            client.Authenticate("enurgucuk@gmail.com", "iexdzknwllkzunxw"); //2.parametreye gmail hesabı izinden aldığımız key değerini veriyoruz
            client.Send(mimeMessage);//mimeMessage'ı gönder
            client.Disconnect(true);


            return View();
        }
    }
}
