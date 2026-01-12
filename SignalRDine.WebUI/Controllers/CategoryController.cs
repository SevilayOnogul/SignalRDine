using Microsoft.AspNetCore.Mvc;

namespace SignalRDine.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
