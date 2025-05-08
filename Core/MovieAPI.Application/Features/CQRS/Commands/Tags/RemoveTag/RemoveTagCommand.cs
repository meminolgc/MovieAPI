using MediatR;

namespace MovieAPI.Application.Features.CQRS.Commands.Tags.RemoveTag
{
	public class RemoveTagCommand : IRequest<RemoveTagCommandResponse>
	{
		public int Id { get; set; }
	}
}
