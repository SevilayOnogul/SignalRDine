using Microsoft.AspNetCore.Mvc;

namespace SignalRDine.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NotFound404Page()
        {
            return View();
        }
    }
}
