using MediatR;
using MovieAPI.Application.Abstractions.Services;

namespace MovieAPI.Application.Features.CQRS.Commands.Movies.UpdateMovie
{
	public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, UpdateMovieCommandResponse>
	{
		private readonly IMovieService _movieService;

		public UpdateMovieCommandHandler(IMovieService movieService)
		{
			_movieService = movieService;
		}

		public async Task<UpdateMovieCommandResponse> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
		{
			await _movieService.UpdateMovieAsync(new()
			{
				Id = request.Id,
				Title = request.Title,
				CategoryId = request.CategoryId,
				CoverImageUrl = request.CoverImageUrl,
				CreatedYear = request.CreatedYear,
				Description = request.Description,
				Duration = request.Duration,
				Rating = request.Rating,
				RelaseTime = request.RelaseTime,
				Status = request.Status
			});

			return new()
			{
				Message = "success",
				Success = true
			};
			
		}
	}
}
