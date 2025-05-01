using MediatR;
using MovieAPI.Application.Repositories.Movie;

namespace MovieAPI.Application.Features.CQRS.Commands.Movies.RemoveMovie
{
	public class RemoveMovieCommandHandler : IRequestHandler<RemoveMovieCommand, RemoveMovieCommandResponse>
	{
		private readonly IMovieWriteRepository _repository;

		public RemoveMovieCommandHandler(IMovieWriteRepository repository)
		{
			_repository = repository;
		}

		public async Task<RemoveMovieCommandResponse> Handle(RemoveMovieCommand request, CancellationToken cancellationToken)
		{
			await _repository.RemoveAsync(request.Id);
			await _repository.SaveAsync();

			return new();
		}
	}
}
