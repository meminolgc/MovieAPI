using MediatR;

namespace MovieAPI.Application.Features.CQRS.Queries.Categories.GetByIdCategory
{
	public class GetByIdCategoryQuery : IRequest<GetByIdCategoryQueryResponse>
	{
		public int Id { get; set; }
	}
}
