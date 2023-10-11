using MailKit.Net.Smtp;
using MailKit.Security;
using ManageFileBE.Dto;
using ManageFileBE.Service.Interface;
using MimeKit;
using MimeKit.Text;

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
            String server = _configuration["MailSettings:Server"];
            String emailFrom = _configuration["MailSettings:SenderEmail"];
            String passwordEmail = _configuration["MailSettings:Password"];
            int port = Convert.ToInt32(_configuration["MailSettings:Port"]);
            var email = new MimeMessage();

            email.From.Add( MailboxAddress.Parse(emailFrom));
            email.To.Add(MailboxAddress.Parse(mailRequest.mailTo));
            email.Subject = mailRequest.Subject;
          /*  email.Body = new TextPart(TextFormat.Plain) { Text = mailRequest.Body };*/
            email.Body = new TextPart(TextFormat.Html) { Text = mailRequest.Body };
            using var smtp = new SmtpClient();
            smtp.Connect(server, port, SecureSocketOptions.StartTls);
            smtp.Authenticate(emailFrom, passwordEmail);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
