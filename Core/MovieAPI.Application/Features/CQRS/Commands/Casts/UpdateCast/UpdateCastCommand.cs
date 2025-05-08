using MediatR;

namespace MovieAPI.Application.Features.CQRS.Commands.Casts.UpdateCast
{
	public class UpdateCastCommand : IRequest<UpdateCastCommandResponse>
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string? ImageUrl { get; set; }
		public string? Overview { get; set; }
		public string? Biography { get; set; }
	}
}
