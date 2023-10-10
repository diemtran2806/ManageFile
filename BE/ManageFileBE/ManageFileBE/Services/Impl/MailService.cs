using ManageFileBE.Dto;
using ManageFileBE.Service.Interface;
using System.Net.Mail;
using System.Net;

namespace ManageFileBE.Service.Impl
{
    public class MailService : IMailService
    {
        private IConfiguration _configuration;
        public MailService(IConfiguration configuration) {
            _configuration = configuration;
        }    
        public void SendEmail(MailRequest mailRequest)
        {
            String emailFrom = _configuration["MailSettings:SenderEmail"];
            String passwordEmail = _configuration["MailSettings:Password"];
            int port = Convert.ToInt32(_configuration["MailSettings:Port"]);
            var smtpClient = new SmtpClient(_configuration["MailSettings:Server"])
            {
                Port = port,
                Credentials = new NetworkCredential(emailFrom, passwordEmail),
                EnableSsl = true,
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress(emailFrom),
                Subject = mailRequest.Subject,
                Body = mailRequest.Body,
            };
            mailMessage.To.Add(mailRequest.mailTo);
            smtpClient.Send(mailMessage);
        }
    }
}
