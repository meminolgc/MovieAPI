using MediatR;
using MovieAPI.Application.Repositories.Movie;

namespace MovieAPI.Application.Features.CQRS.Commands.Movies.UpdateMovie
{
	public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, UpdateMovieCommandResponse>
	{
		private readonly IMovieWriteRepository _movieWriteRepository;
		private readonly IMovieReadRepository _movieReadRepository;

		public UpdateMovieCommandHandler(IMovieWriteRepository movieWriteRepository,
			IMovieReadRepository movieReadRepository)
		{
			_movieWriteRepository = movieWriteRepository;
			_movieReadRepository = movieReadRepository;
		}

		public async Task<UpdateMovieCommandResponse> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
		{
			Domain.Entities.Movie movie = await _movieReadRepository.GetByIdAsync(request.MovieId);
			if (movie == null)
			{
				return new()
				{
					Message = "not found",
					Success = false
				};
			}

			movie.Title = request.Title;
			movie.Status = request.Status;
			movie.Description = request.Description;
			movie.Rating = request.Rating;
			movie.CreatedYear = request.CreatedYear;
			movie.CoverImageUrl = request.CoverImageUrl;
			movie.Duration = request.Duration;
			movie.RelaseTime = request.RelaseTime;
			movie.CategoryId = request.CategoryId;

			await _movieWriteRepository.SaveAsync();
			return new()
			{
				Message = "success",
				Success = true
			};
			
		}
	}
}
