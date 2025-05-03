using MediatR;
using MovieAPI.Application.Repositories.Movie;

namespace MovieAPI.Application.Features.CQRS.Queries.Movies.GetByIdMovie
{
	public class GetByIdMovieQueryHandler : IRequestHandler<GetByIdMovieQuery, GetByIdMovieQueryResponse>
	{
		private readonly IMovieReadRepository _repository;

		public GetByIdMovieQueryHandler(IMovieReadRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetByIdMovieQueryResponse> Handle(GetByIdMovieQuery request, CancellationToken cancellationToken)
		{
			var movie = await _repository.GetByIdAsync(request.Id);
			return new()
			{
				Id = movie.Id,
				CoverImageUrl = movie.CoverImageUrl,
				CreatedYear = movie.CreatedYear,
				Description = movie.Description,
				Duration = movie.Duration,
				Rating = movie.Rating, 
				RelaseTime = movie.RelaseTime,
				Status = movie.Status,
				Title = movie.Title
			};
		}
	}
}
