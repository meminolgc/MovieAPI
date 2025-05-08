using MediatR;

namespace MovieAPI.Application.Features.CQRS.Commands.Casts.RemoveCast
{
	public class RemoveCastCommand : IRequest<RemoveCastCommandResponse>
	{
		public int Id { get; set; }
	}
}
