using MovieAPI.Application.Repositories.Tag;
using MovieAPI.Persistence.Contexts;

namespace MovieAPI.Persistence.Repositories.Tag
{
	public class TagWriteRepository : WriteRepository<Domain.Entities.Tag>, ITagWriteRepository
	{
		public TagWriteRepository(MovieAPIDbContext context) : base(context)
		{
		}
	}
}
