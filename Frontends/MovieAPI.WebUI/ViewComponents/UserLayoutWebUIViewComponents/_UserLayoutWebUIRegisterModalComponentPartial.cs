using Microsoft.AspNetCore.Mvc;

namespace MovieAPI.WebUI.ViewComponents.UserLayoutWebUIViewComponents
{
	public class _UserLayoutWebUIRegisterModalComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();	
		}
	}
}
