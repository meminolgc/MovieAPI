using MovieAPI.Application.Repositories.Category;
using MovieAPI.Persistence.Contexts;

namespace MovieAPI.Persistence.Repositories.Category
{
	public class CategoryReadRepository : ReadRepository<Domain.Entities.Category>, ICategoryReadRepository
	{
		public CategoryReadRepository(MovieAPIDbContext context) : base(context)
		{
		}
	}
}
