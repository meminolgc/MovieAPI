using MovieAPI.Application.Dtos.Movie;
using MovieAPI.Application.Features.CQRS.Queries.Movies.GetFilteredMovie;

namespace MovieAPI.Application.Abstractions.Services
{
	public interface IMovieService
	{
		public Task CreateMovieAsync(MovieServiceDto movie);
		public Task RemoveMovieAsync(int id);
		public Task UpdateMovieAsync(MovieServiceDto updateMovie);
		public Task<List<ResultMovieDto>> GetAllMovieAsync();
		public Task<MovieServiceDto> GetByIdMovieAsync(int id);
		Task<List<ResultMovieDto>> GetFilteredMovieAsync(MovieFilterModel filter);

	}
}
