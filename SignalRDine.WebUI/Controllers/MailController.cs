using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRDine.WebUI.Dtos.MailDtos;

public class MailController : Controller
{
    [HttpGet]
    public IActionResult Index() => View();

    [HttpPost]
    public IActionResult Index(CreateMailDto createMailDto)
    {
        try
        {
            MimeMessage mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress("SignalR Rezervasyon", "apikurs2@gmail.com"));
            mimeMessage.To.Add(new MailboxAddress("User", createMailDto.ReceiverMail));

            var bodyBuilder = new BodyBuilder { HtmlBody = createMailDto.Body };
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = createMailDto.Subject;

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com", 587, false);
                smtpClient.Authenticate("apikurs2@gmail.com", "jkkj wwfm uhur zcps");
                smtpClient.Send(mimeMessage);
                smtpClient.Disconnect(true);
            }

            TempData["MailStatus"] = "Success";
            return RedirectToAction("Index", "Category");
        }
        catch
        {
            TempData["MailStatus"] = "Error";
            return View();
        }
    }
}