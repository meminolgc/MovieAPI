using MovieAPI.Application.Repositories.Category;
using MovieAPI.Persistence.Contexts;

namespace MovieAPI.Persistence.Repositories.Category
{
	public class CategoryWriteRepository : WriteRepository<Domain.Entities.Category>, ICategoryWriteRepository
	{
		public CategoryWriteRepository(MovieAPIDbContext context) : base(context)
		{
		}
	}
}
