using MovieAPI.Application.Repositories.Review;
using MovieAPI.Persistence.Contexts;

namespace MovieAPI.Persistence.Repositories.Review
{
	public class ReviewReadRepository : ReadRepository<Domain.Entities.Review>, IReviewReadRepository
	{
		public ReviewReadRepository(MovieAPIDbContext context) : base(context)
		{
		}
	}
}
