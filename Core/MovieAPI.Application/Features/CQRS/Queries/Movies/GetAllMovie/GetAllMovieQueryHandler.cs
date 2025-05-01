using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Application.Dtos.Movie;
using MovieAPI.Application.Repositories.Movie;

namespace MovieAPI.Application.Features.CQRS.Queries.Movies.GetAllMovie
{
	public class GetAllMovieQueryHandler : IRequestHandler<GetAllMovieQuery, GetAllMovieQueryResponse>
	{
		private readonly IMovieReadRepository _repository;

		public GetAllMovieQueryHandler(IMovieReadRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetAllMovieQueryResponse> Handle(GetAllMovieQuery request, CancellationToken cancellationToken)
		{
			var movies = await _repository.GetAll().ToListAsync();
			var movieDtos = movies.Select(x => new GetAllMovieDto
			{
				CoverImageUrl = x.CoverImageUrl,
				CreatedYear = x.CreatedYear,
				Description = x.Description,
				Duration = x.Duration,
				Rating = x.Rating,
				RelaseTime = x.RelaseTime,
				Status = x.Status,
				Title = x.Title
			}).ToList();

			return new()
			{
				Movies = movieDtos
			};
		}
	}
}
