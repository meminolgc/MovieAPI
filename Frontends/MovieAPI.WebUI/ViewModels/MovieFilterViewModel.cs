using Microsoft.AspNetCore.Mvc.Rendering;
using MovieAPI.Application.Dtos.Movie;

namespace MovieAPI.WebUI.ViewModels
{
	public class MovieFilterViewModel
	{
		public string? Title { get; set; }
		public List<int>? CategoryIds { get; set; }
		public decimal? MinRating { get; set; }
		public decimal? MaxRating { get; set; }
		public int? StartYear { get; set; }
		public int? EndYear { get; set; }

		public List<SelectListItem> Categories { get; set; } = new();
		public List<MovieListDto> FilteredMovies { get; set; } = new();
	}
}
