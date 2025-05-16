using Microsoft.AspNetCore.Mvc;

namespace MovieAPI.WebUI.ViewComponents.MovieDetailViewComponents
{
	public class _MovieDetailRelatedMoviesComponentPartial :  ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
