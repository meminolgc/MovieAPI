using MovieAPI.Application.Repositories.Movie;
using MovieAPI.Persistence.Contexts;

namespace MovieAPI.Persistence.Repositories.Movie
{
	public class MovieWriteRepository : WriteRepository<Domain.Entities.Movie>, IMovieWriteRepository
	{
		public MovieWriteRepository(MovieAPIDbContext context) : base(context)
		{
		}
	}
}
