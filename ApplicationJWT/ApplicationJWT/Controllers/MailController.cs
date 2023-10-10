using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Asn1.Pkcs;
using System.Net;
using System.Net.Mail;

namespace ApplicationJWT.Controllers
{
    [ApiController]
    [Route("api/email")]
    public class MailController : ControllerBase
    {
        [HttpGet]
        public IActionResult sendEmail([FromBody] MailRequest mail)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("caohuuhieu12b8@gmail.com", "jvaq demk jxoc lxiv"),
                    EnableSsl = true,
                };
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("caohuuhieu12b8@gmail.com"),
                    Subject = "This is subject",
                    Body = "This is body",
                };
                mailMessage.To.Add("tranvansy197@gmail.com");
                smtpClient.Send(mailMessage);
                return Ok("Email đã được gửi thành công.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Gửi email thất bại: {ex.Message}");
            }
        }
    }
}
