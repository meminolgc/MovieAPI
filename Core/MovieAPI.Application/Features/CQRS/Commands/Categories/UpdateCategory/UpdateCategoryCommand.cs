using MediatR;

namespace MovieAPI.Application.Features.CQRS.Commands.Categories.UpdateCategory
{
	public class UpdateCategoryCommand : IRequest<UpdateCategoryCommandResponse>
	{
		public int Id { get; set; }
		public string CategoryName { get; set; }
	}
}
