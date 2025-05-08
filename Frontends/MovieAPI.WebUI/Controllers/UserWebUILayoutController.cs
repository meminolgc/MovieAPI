using Microsoft.AspNetCore.Mvc;

namespace MovieAPI.WebUI.Controllers
{
	public class UserWebUILayoutController : Controller
	{
		public IActionResult LayoutUI()
		{
			return View();
		}
	}
}
