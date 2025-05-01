using MovieAPI.Application.Repositories.Cast;
using MovieAPI.Persistence.Contexts;

namespace MovieAPI.Persistence.Repositories.Cast
{
	public class CastWriteRepository : WriteRepository<Domain.Entities.Cast>, ICastWriteRepository
	{
		public CastWriteRepository(MovieAPIDbContext context) : base(context)
		{
		}
	}
}
