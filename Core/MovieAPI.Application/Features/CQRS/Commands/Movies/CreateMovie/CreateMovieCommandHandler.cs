using MediatR;
using MovieAPI.Application.Abstractions.Services;

namespace MovieAPI.Application.Features.CQRS.Commands.Movies.CreateMovie
{
	public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, CreateMovieCommandResponse>
	{
		private readonly IMovieService _movieService;

		public CreateMovieCommandHandler(IMovieService movieService)
		{
			_movieService = movieService;
		}

		public async Task<CreateMovieCommandResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
		{
			await _movieService.CreateMovieAsync(new()
			{
				Title = request.Title,
				Description = request.Description,
				CoverImageUrl = request.CoverImageUrl,
				Duration = request.Duration,
				CreatedYear = request.CreatedYear,
				Rating = request.Rating,
				RelaseTime = request.RelaseTime,
				Status = request.Status,
				CategoryId = request.CategoryId
			});

			return new()
			{
				Message = "başarılı",
				Success = true
			};
		}
	}
}
