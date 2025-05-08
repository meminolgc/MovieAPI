using MediatR;
using MovieAPI.Application.Repositories.Category;

namespace MovieAPI.Application.Features.CQRS.Commands.Categories.RemoveCategory
{
	public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand, RemoveCategoryCommandResponse>
	{
		private readonly ICategoryWriteRepository _repository;

		public RemoveCategoryCommandHandler(ICategoryWriteRepository repository)
		{
			_repository = repository;
		}

		public async Task<RemoveCategoryCommandResponse> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
		{
			await _repository.RemoveAsync(request.Id);
			await _repository.SaveAsync();

			return new();
		}
	}
}
