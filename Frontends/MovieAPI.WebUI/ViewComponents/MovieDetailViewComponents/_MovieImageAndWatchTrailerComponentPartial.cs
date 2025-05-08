using Microsoft.AspNetCore.Mvc;

namespace MovieAPI.WebUI.ViewComponents.MovieDetailViewComponents
{
	public class _MovieImageAndWatchTrailerComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
