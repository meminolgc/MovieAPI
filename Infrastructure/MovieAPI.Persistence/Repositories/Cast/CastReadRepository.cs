using MovieAPI.Application.Repositories.Cast;
using MovieAPI.Persistence.Contexts;

namespace MovieAPI.Persistence.Repositories.Cast
{
	public class CastReadRepository : ReadRepository<Domain.Entities.Cast>, ICastReadRepository
	{
		public CastReadRepository(MovieAPIDbContext context) : base(context)
		{
		}
	}
}
