using MediatR;
using MovieAPI.Application.Repositories.Category;

namespace MovieAPI.Application.Features.CQRS.Commands.Categories.CreateCategory
{
	public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
	{
		private readonly ICategoryWriteRepository _repository;

		public CreateCategoryCommandHandler(ICategoryWriteRepository repository)
		{
			_repository = repository;
		}

		public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
		{
			var category = await _repository.AddAsync(new Domain.Entities.Category
			{
				CategoryName = request.CategoryName,
			});

			await _repository.SaveAsync();

			return new()
			{
				CategoryId = category.Id,
				Success = true,
				Message = "Category created successfully."
			};
		}
	}
}
