using MediatR;
using MovieAPI.Application.Dtos.Movie;

namespace MovieAPI.Application.Features.CQRS.Queries.Movies.GetFilteredMovie
{
	public class GetFilteredMovieQuery : IRequest<List<ResultMovieDto>>
	{
		public MovieFilterModel Filter { get; set; }

		public GetFilteredMovieQuery(MovieFilterModel filter)
		{
			Filter = filter;
		}
	}
}
