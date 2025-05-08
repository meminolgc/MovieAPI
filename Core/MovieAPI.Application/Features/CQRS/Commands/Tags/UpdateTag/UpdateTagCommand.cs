using MediatR;

namespace MovieAPI.Application.Features.CQRS.Commands.Tags.UpdateTag
{
	public class UpdateTagCommand : IRequest<UpdateTagCommandResponse>
	{
		public int Id { get; set; }
		public string Title { get; set; }

	}
}
