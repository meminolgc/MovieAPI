using MediatR;

namespace MovieAPI.Application.Features.CQRS.Commands.Categories.CreateCategory
{
	public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
	{
		public string CategoryName { get; set; }
	}
}
