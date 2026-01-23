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
            try
            {
                MimeMessage mimeMessage = new MimeMessage();

                MailboxAddress mailboxAddressFrom = new MailboxAddress("SignalR Rezervasyon", "apikurs2@gmail.com");
                mimeMessage.From.Add(mailboxAddressFrom);

                MailboxAddress mailboxAddressTo = new MailboxAddress("User", createMailDto.ReceiverMail);
                mimeMessage.To.Add(mailboxAddressTo);

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = createMailDto.Body;
                mimeMessage.Body = bodyBuilder.ToMessageBody();

                mimeMessage.Subject = createMailDto.Subject;

                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.Connect("smtp.gmail.com", 587, false);
                    smtpClient.Authenticate("apikurs2@gmail.com", "jkkj wwfm uhur zcps");
                    smtpClient.Send(mimeMessage);
                    smtpClient.Disconnect(true);
                }

                // Başarılı bildirim sinyali
                TempData["MailStatus"] = "Success";
                return RedirectToAction("Index", "Category");
            }
            catch (Exception)
            {
                // Hata durumunda kullanıcıya bilgi vermek için
                TempData["MailStatus"] = "Error";
                return View();
            }
        }
    }
}