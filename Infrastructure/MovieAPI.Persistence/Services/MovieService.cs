using Microsoft.EntityFrameworkCore;
using MovieAPI.Application.Abstractions.Services;
using MovieAPI.Application.Dtos.Movie;
using MovieAPI.Application.Repositories.Movie;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Persistence.Services
{
	public class MovieService : IMovieService
	{
		private readonly IMovieReadRepository _readRepository;
		private readonly IMovieWriteRepository _writeRepository;

		public MovieService(IMovieReadRepository readRepository, IMovieWriteRepository writeRepository)
		{
			_readRepository = readRepository;
			_writeRepository = writeRepository;
		}

		public async Task CreateMovieAsync(MovieServiceDto movie)
		{
			var movieResult = await _writeRepository.AddAsync(new()
			{
				Title = movie.Title,
				CoverImageUrl = movie.CoverImageUrl,
				CreatedYear = movie.CreatedYear,
				Description = movie.Description,
				Duration = movie.Duration,
				Rating = movie.Rating,
				RelaseTime = movie.RelaseTime,
				Status = movie.Status,
				CategoryId = movie.CategoryId
			});
			await _writeRepository.SaveAsync();
		}

		public async Task<List<ResultMovieDto>> GetAllMovieAsync()
		{
			var movies = await _readRepository.GetAll().ToListAsync();

			var movieDtos = movies.Select(x => new ResultMovieDto
			{
				Id = x.Id,
				CoverImageUrl = x.CoverImageUrl,
				CreatedYear = x.CreatedYear,
				Description = x.Description,
				Duration = x.Duration,
				Rating = x.Rating,
				RelaseTime = x.RelaseTime,
				Status = x.Status,
				Title = x.Title,
				CategoryId = x.CategoryId
			}).ToList();

			return movieDtos;
		}

		public async Task<MovieServiceDto> GetByIdMovieAsync(int id)
		{
			var movie = await _readRepository.GetByIdAsync(id);

			return new()
			{
				Id = movie.Id,
				CoverImageUrl = movie.CoverImageUrl,
				CreatedYear = movie.CreatedYear,
				Description = movie.Description,
				Duration = movie.Duration,
				Rating = movie.Rating,
				RelaseTime = movie.RelaseTime,
				Status = movie.Status,
				Title = movie.Title,
				CategoryId = movie.CategoryId,
			};
		}

		public async Task RemoveMovieAsync(int id)
		{
			await _writeRepository.RemoveAsync(id);
			await _writeRepository.SaveAsync();

		}

		public async Task UpdateMovieAsync(MovieServiceDto updateMovie)
		{
			Movie movie = await _readRepository.GetByIdAsync(updateMovie.Id);

			movie.Title = updateMovie.Title;
			movie.Status = updateMovie.Status;
			movie.Description = updateMovie.Description;
			movie.Rating = updateMovie.Rating;
			movie.CreatedYear = updateMovie.CreatedYear;
			movie.CoverImageUrl = updateMovie.CoverImageUrl;
			movie.Duration = updateMovie.Duration;
			movie.RelaseTime = updateMovie.RelaseTime;
			movie.CategoryId = updateMovie.CategoryId;

			await _writeRepository.SaveAsync();

		}
	}
}
