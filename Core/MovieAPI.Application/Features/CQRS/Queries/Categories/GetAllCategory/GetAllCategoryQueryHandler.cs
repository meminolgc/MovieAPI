using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Application.Dtos.Category;
using MovieAPI.Application.Repositories.Category;

namespace MovieAPI.Application.Features.CQRS.Queries.Categories.GetAllCategory
{
	public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, GetAllCategoryQueryResponse>
	{
		private readonly ICategoryReadRepository _repository;

		public GetAllCategoryQueryHandler(ICategoryReadRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetAllCategoryQueryResponse> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
		{
			var categories = await _repository.GetAll().ToListAsync();
			var categoryDtos = categories.Select(x => new GetAllCategoryDto
			{
				CategoryName = x.CategoryName
			}).ToList();
				
			return new()
			{
				Categories = categoryDtos
			};
		}
	}
}
