using ManageFileBE.Dto;
using ManageFileBE.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManageFileBE.Controllers
{
    [Route("api/mail")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;
        public MailController(IMailService mailService) { 
            _mailService = mailService;
        }
        [HttpPost]
        public IActionResult SendMail([FromBody] MailRequest mailRequest)
        {
            try
            {
                _mailService.SendEmail(mailRequest);
                return Ok(new { message = "Send mail success" });
            }catch(Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
                return StatusCode(500, new { message = "Internal server error" });
            }
        }
    }
}
