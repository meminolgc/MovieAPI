using MediatR;
using MovieAPI.Application.Abstractions.Services;

namespace MovieAPI.Application.Features.CQRS.Commands.Movies.RemoveMovie
{
	public class RemoveMovieCommandHandler : IRequestHandler<RemoveMovieCommand, RemoveMovieCommandResponse>
	{
		private readonly IMovieService _movieService;

		public RemoveMovieCommandHandler(IMovieService movieService)
		{
			_movieService = movieService;
		}

		public async Task<RemoveMovieCommandResponse> Handle(RemoveMovieCommand request, CancellationToken cancellationToken)
		{
			await _movieService.RemoveMovieAsync(request.Id);
			return new();
		}
	}
}
