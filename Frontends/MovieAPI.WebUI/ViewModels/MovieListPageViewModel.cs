using MovieAPI.Application.Dtos.Movie;

namespace MovieAPI.WebUI.ViewModels
{
	public class MovieListPageViewModel
	{
		public MovieFilterViewModel Filter { get; set; } = new();
		public List<ResultMovieDto> ResultMovies { get; set; } = new();
	}
}
