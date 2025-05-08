using MediatR;

namespace MovieAPI.Application.Features.CQRS.Commands.Tags.CreateTag
{
	public class CreateTagCommand : IRequest<CreateTagCommandResponse>
	{
		public string Title { get; set; }

	}
}
