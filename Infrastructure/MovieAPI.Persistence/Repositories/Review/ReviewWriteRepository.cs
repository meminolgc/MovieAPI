using MovieAPI.Application.Repositories.Review;
using MovieAPI.Persistence.Contexts;

namespace MovieAPI.Persistence.Repositories.Review
{
	public class ReviewWriteRepository : WriteRepository<Domain.Entities.Review>, IReviewWriteRepository
	{
		public ReviewWriteRepository(MovieAPIDbContext context) : base(context)
		{
		}
	}
}
