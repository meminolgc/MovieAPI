using MovieAPI.Application.Repositories.Tag;
using MovieAPI.Persistence.Contexts;

namespace MovieAPI.Persistence.Repositories.Tag
{
	public class TagReadRepository : ReadRepository<Domain.Entities.Tag>, ITagReadRepository
	{
		public TagReadRepository(MovieAPIDbContext context) : base(context)
		{
		}
	}
}
