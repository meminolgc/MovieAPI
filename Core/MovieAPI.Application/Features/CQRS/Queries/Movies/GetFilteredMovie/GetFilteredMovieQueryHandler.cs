using MediatR;
using MovieAPI.Application.Abstractions.Services;
using MovieAPI.Application.Dtos.Movie;

namespace MovieAPI.Application.Features.CQRS.Queries.Movies.GetFilteredMovie
{
	public class GetFilteredMovieQueryHandler : IRequestHandler<GetFilteredMovieQuery, List<ResultMovieDto>>
	{
		private readonly IMovieService _movieService;

		public GetFilteredMovieQueryHandler(IMovieService movieService)
		{
			_movieService = movieService;
		}

		public async Task<List<ResultMovieDto>> Handle(GetFilteredMovieQuery request, CancellationToken cancellationToken)
		{
			return await _movieService.GetFilteredMovieAsync(request.Filter);
		}
	}
}
