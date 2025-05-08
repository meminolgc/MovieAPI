using MovieAPI.Application.Dtos.Movie;

namespace MovieAPI.Application.Features.CQRS.Queries.Movies.GetAllMovie
{
	public class GetAllMovieQueryResponse
	{
		public List<ResultMovieDto> Movies { get; set; }

	}
}
