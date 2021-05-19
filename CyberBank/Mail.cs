using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CyberBank
{
    class Mail
    {
        public void send_mail(string email)
        {
            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress("cyberbank@tickok.com", "Кибербанк");
            message.To.Add($"{email}");
            message.Subject = "Заявка по кредиту";
            message.Body = "<div style=\"color:red;\">Вам одобрен кредит</div>";
            using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
            {
                client.Credentials = new NetworkCredential("glebok.0804@gmail.com", mail_cred.pass);
                client.Port = 587;
                client.EnableSsl = true;
                client.Send(message);
            }
        }
    }
}
