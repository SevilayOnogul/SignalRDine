using Microsoft.AspNetCore.Mvc;

namespace SignalRDine.WebUI.Controllers
{
    public class SignalRDefaultController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Index2() => View();

    }
}
