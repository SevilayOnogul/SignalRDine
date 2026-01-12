using Microsoft.AspNetCore.Mvc;

namespace SignalRDine.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
