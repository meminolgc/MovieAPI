using MovieAPI.Application.Repositories.Movie;
using MovieAPI.Persistence.Contexts;

namespace MovieAPI.Persistence.Repositories.Movie
{
	public class MovieReadRepository : ReadRepository<Domain.Entities.Movie>, IMovieReadRepository
	{
		public MovieReadRepository(MovieAPIDbContext context) : base(context)
		{
		}
	}
}
