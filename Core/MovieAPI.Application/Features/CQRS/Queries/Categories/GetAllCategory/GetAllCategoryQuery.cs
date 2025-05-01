using MediatR;

namespace MovieAPI.Application.Features.CQRS.Queries.Categories.GetAllCategory
{
	public class GetAllCategoryQuery : IRequest<GetAllCategoryQueryResponse>
	{
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
	}
}
