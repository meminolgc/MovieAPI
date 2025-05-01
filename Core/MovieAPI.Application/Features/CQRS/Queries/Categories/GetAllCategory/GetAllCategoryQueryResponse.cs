using MovieAPI.Application.Dtos.Category;

namespace MovieAPI.Application.Features.CQRS.Queries.Categories.GetAllCategory
{
	public class GetAllCategoryQueryResponse 
	{
		public List<GetAllCategoryDto> Categories { get; set; }
	}
}
