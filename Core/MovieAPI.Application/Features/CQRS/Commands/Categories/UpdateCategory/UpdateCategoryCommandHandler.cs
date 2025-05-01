using MediatR;
using MovieAPI.Application.Repositories.Category;

namespace MovieAPI.Application.Features.CQRS.Commands.Categories.UpdateCategory
{
	public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryCommandResponse>
	{
		private readonly ICategoryWriteRepository _categoryWriteRepository;
		private readonly ICategoryReadRepository _categoryReadRepository;

		public UpdateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository,
			ICategoryReadRepository categoryReadRepository)
		{
			_categoryWriteRepository = categoryWriteRepository;
			_categoryReadRepository = categoryReadRepository;
		}

		public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
		{
			 Domain.Entities.Category category = await _categoryReadRepository.GetByIdAsync(request.Id);
		
			if (category == null)
			{
				return new()
				{
					Message = "Category not found",
					Success = false
				};
			}

			category.CategoryName = request.CategoryName;
			await _categoryWriteRepository.SaveAsync();
			return new()
			{
				Message = "Success",
				Success = true
			};
		}
	}
}