using Microsoft.AspNetCore.Mvc;

namespace SignalRDine.WebUI.ViewComponents.LayoutComponents
{
	public class _LayoutNavbarComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
