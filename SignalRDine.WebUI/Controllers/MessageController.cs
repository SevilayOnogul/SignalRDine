using Microsoft.AspNetCore.Mvc;

namespace SignalRDine.WebUI.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()=>View();

        public IActionResult ClientUserCount()=>View();
    }
}
