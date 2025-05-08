using MediatR;

namespace MovieAPI.Application.Features.CQRS.Commands.Categories.RemoveCategory
{
	public class RemoveCategoryCommand : IRequest<RemoveCategoryCommandResponse>
	{
		public int Id { get; set; }
	}
}
