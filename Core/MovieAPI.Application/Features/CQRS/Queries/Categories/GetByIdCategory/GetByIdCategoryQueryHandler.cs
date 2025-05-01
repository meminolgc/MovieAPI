using MediatR;
using MovieAPI.Application.Repositories.Category;

namespace MovieAPI.Application.Features.CQRS.Queries.Categories.GetByIdCategory
{
	public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, GetByIdCategoryQueryResponse>
	{
		private readonly ICategoryReadRepository _categoryReadRepository;

		public GetByIdCategoryQueryHandler(ICategoryReadRepository categoryReadRepository)
		{
			_categoryReadRepository = categoryReadRepository;
		}

		public async Task<GetByIdCategoryQueryResponse> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
		{
			var category = await _categoryReadRepository.GetByIdAsync(request.CategoryId);
			return new()
			{
				CategoryName = category.CategoryName
			};
		}
	}
}
