using MailKit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingHelperServer.Services; // Replace with the actual namespace for IMailService
using TrainingHelperServer.ModelsBL; // Ensure MailData is accessible



namespace TrainingHelperServer.Controllers
{
    [Route("api")]
    [ApiController]
    public class MailController : ControllerBase
    {

        private readonly Services.IMailService _mailService;
        public MailController(Services.IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost]
        [Route("SendMail")]
        public bool SendMail(MailData mailData)
        {
            return _mailService.SendMail(mailData);
        }
    }
}
