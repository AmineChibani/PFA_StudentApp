using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace StudentApp.Services
{
    public class MailSenderService : IServiceSender
    {
        private readonly IConfiguration _configuration;
        public EmailEntity _emailEntity { get; set; }

        public MailSenderService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public bool SendMessage()
        {
            var username = _configuration["EmailConfig:Username"];
            var password = _configuration["EmailConfig:Password"];
            var host = _configuration["EmailConfig:Host"];
            var port = _configuration.GetValue<int>("EmailConfig:Port");
            var fromEmail = _configuration["EmailConfig:FromEmail"];

            using (var message = new MailMessage())
            using (var smtpClient = new SmtpClient(host, port))
            {
                message.From = new MailAddress(fromEmail);
                message.To.Add(_emailEntity.ToEmailAddress.ToString());
                message.Subject = _emailEntity.EmailSubject;
                message.IsBodyHtml = true;
                message.Body = _emailEntity.EmailBody;

                if (_emailEntity.Attachement != null)
                {
                    message.Attachments.Add(new Attachment(_emailEntity.Attachement.OpenReadStream(), _emailEntity.Attachement.FileName));
                }

                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(username, password);

                try
                {
                    smtpClient.Send(message);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
