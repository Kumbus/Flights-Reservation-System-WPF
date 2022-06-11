using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public  class MailSender
    {
        public void Send(string email)
        {
            MailMessage mailMessage = new MailMessage("jakubek2333@gmail.com", email);

            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            mailMessage.Subject = "this is a test email.";
            mailMessage.Body = "this is my test email body";
            client.Send(mailMessage);
        }
    }
}
