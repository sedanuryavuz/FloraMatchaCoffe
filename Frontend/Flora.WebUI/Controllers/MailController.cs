using Flora.WebUI.Dtos.MailDtos;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace Flora.WebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Flora", "sedanuryavz8@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddress = new MailboxAddress("User", createMailDto.ReceiverMail);
            mimeMessage.To.Add(mailboxAddress);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = createMailDto.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = createMailDto.Subject;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("sedanuryavz8@gmail.com", "eylu pcdg pbjn pwms\r\n");

            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            return RedirectToAction("Index","Categoy");
        }
    }
}
