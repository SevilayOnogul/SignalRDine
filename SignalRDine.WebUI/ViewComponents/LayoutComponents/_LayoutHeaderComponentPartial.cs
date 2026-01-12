using Microsoft.AspNetCore.Mvc;

namespace SignalRDine.WebUI.ViewComponents.LayoutComponents
{
    public class _LayoutHeaderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
