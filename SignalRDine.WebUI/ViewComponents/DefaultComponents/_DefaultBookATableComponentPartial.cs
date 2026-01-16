using Microsoft.AspNetCore.Mvc;

namespace SignalRDine.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultBookATableComponentPartial:ViewComponent
    {
      
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
