using MediatR;
using MovieAPI.Application.Repositories.Movie;

namespace MovieAPI.Application.Features.CQRS.Commands.Movies.CreateMovie
{
	public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, CreateMovieCommandResponse>
	{
		private readonly IMovieWriteRepository _repository;

		public CreateMovieCommandHandler(IMovieWriteRepository repository)
		{
			_repository = repository;
		}

		public async Task<CreateMovieCommandResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
		{
			var movie = await _repository.AddAsync(new Domain.Entities.Movie
			{
				Title = request.Title,
				CoverImageUrl = request.CoverImageUrl,
				CreatedYear = request.CreatedYear,
				Description = request.Description,
				Duration = request.Duration,
				Rating = request.Rating,
				RelaseTime = request.RelaseTime,
				Status = request.Status,
			});
			await _repository.SaveAsync();

			return new()
			{
				Message = "başarılı",
				Success = true
			};
		}
	}
}
