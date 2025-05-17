using MediatR;
using MovieAPI.Application.Abstractions.Services;

namespace MovieAPI.Application.Features.CQRS.Queries.Movies.GetAllMovie
{
	public class GetAllMovieQueryHandler : IRequestHandler<GetAllMovieQuery, GetAllMovieQueryResponse>
	{
		private readonly IMovieService _movieService;

		public GetAllMovieQueryHandler(IMovieService movieService)
		{
			_movieService = movieService;
		}

		public async Task<GetAllMovieQueryResponse> Handle(GetAllMovieQuery request, CancellationToken cancellationToken)
		{
			var movies = await _movieService.GetAllMovieAsync();

			return new()
			{
				Movies = movies
			};
		}
	}
}
