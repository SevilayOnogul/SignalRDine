using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRDine.WebUI.Dtos.MailDtos;

namespace SignalRDine.WebUI.Controllers
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
            MimeMessage mimeMessage=new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("SignalR Rezervasyon", "sevilaygalatasaray5@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", createMailDto.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder=new BodyBuilder();
            bodyBuilder.HtmlBody=createMailDto.Body;
            mimeMessage.Body=bodyBuilder.ToMessageBody();

            mimeMessage.Subject = createMailDto.Subject;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("sevilaygalatasaray5@gmail.com", "wworxavzlxgkwmqb");

            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);


            return RedirectToAction("Index","Category");
        }
    }
}
