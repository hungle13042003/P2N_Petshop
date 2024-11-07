using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.UtilsService
{
    public class EmailService : IEmailService
    {
        private readonly string SmtpHost = "smtp.gmail.com";
        private readonly int SmtpPort = 587;
        private readonly string SmtpUser = "p2npetshop@gmail.com";
        private readonly string SmtpPass = "jvapoxyfnjtrpiod";
        //private readonly string PasswordRoot = "nhattaisin9999";

        public EmailService()
        {

        }

        public void Send(string to, string subject, string html)
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(SmtpUser));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect(SmtpHost, SmtpPort, SecureSocketOptions.StartTls);
            smtp.Authenticate(SmtpUser, SmtpPass);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
