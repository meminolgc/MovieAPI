using MediatR;

namespace MovieAPI.Application.Features.CQRS.Commands.Movies.RemoveMovie
{
	public class RemoveMovieCommand : IRequest<RemoveMovieCommandResponse>
	{
		public int Id { get; set; }
	}
}
