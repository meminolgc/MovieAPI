using MediatR;
using MovieAPI.Application.Abstractions.Services;

namespace MovieAPI.Application.Features.CQRS.Queries.Movies.GetByIdMovie
{
	public class GetByIdMovieQueryHandler : IRequestHandler<GetByIdMovieQuery, GetByIdMovieQueryResponse>
	{
		private readonly IMovieService _movieService;

		public GetByIdMovieQueryHandler(IMovieService movieService)
		{
			_movieService = movieService;
		}

		public async Task<GetByIdMovieQueryResponse> Handle(GetByIdMovieQuery request, CancellationToken cancellationToken)
		{
			var movie = await _movieService.GetByIdMovieAsync(request.Id);

			return new()
			{
				Id = movie.Id,
				Title = movie.Title,
				Description = movie.Description,
				CoverImageUrl = movie.CoverImageUrl,
				CreatedYear = movie.CreatedYear,
				Rating = movie.Rating,
				Duration = movie.Duration,
				Status = movie.Status,
				CategoryId = movie.CategoryId,
				RelaseTime = movie.RelaseTime
			};

		}
	}
}
