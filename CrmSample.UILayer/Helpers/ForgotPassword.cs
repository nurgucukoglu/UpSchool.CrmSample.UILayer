using System.Net.Mail;

namespace CrmSample.UILayer.Helpers
{
    public class ForgotPassword
    {
        public static void SendEmailPasswordReset(string email, string link)
        {
            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress("testpostasi2@outlook.com");
            mailMessage.To.Add(email);

            mailMessage.Subject = "Password Reset";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = link;

            SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com");
            smtpClient.Credentials = new System.Net.NetworkCredential("testpostasi2@outlook.com", "Eminenur01");
            smtpClient.Host = "smtp-mail.outlook.com";
            smtpClient.Port = 587;
            smtpClient.Send(mailMessage);

        }
    }
}
