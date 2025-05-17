using MovieAPI.Application.Dtos.Movie;
using MovieAPI.Application.Features.CQRS.Queries.Movies.GetFilteredMovie;

namespace MovieAPI.WebUI.ViewModels
{
	public class MovieFilterViewModel
	{
		public MovieFilterModel Filter { get; set; } = new();
		public List<ResultMovieDto> Movies { get; set; } = new();
	}
}
