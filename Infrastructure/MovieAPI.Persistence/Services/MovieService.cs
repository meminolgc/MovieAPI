using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MovieAPI.Application.Abstractions.Services;
using MovieAPI.Application.Dtos.Movie;
using MovieAPI.Application.Features.CQRS.Queries.Movies.GetFilteredMovie;
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

		public async Task<List<ResultMovieDto>> GetFilteredMovieAsync(MovieFilterModel filter)
		{
			var query = _readRepository.GetAll().Include(x => x.Category).AsQueryable();

			// Başlık filtreleme
			if (!string.IsNullOrEmpty(filter.Title))
			{
				query = query.Where(m => m.Title.Contains(filter.Title));
			}

			// Kategori filtreleme (çoklu seçim)
			if (filter.CategoryIds != null && filter.CategoryIds.Any())
			{
				query = query.Where(m => filter.CategoryIds.Contains(m.CategoryId));
			}

			// Reyting filtreleme
			if (filter.MinRating.HasValue)
			{
				query = query.Where(m => m.Rating >= filter.MinRating.Value);
			}
			if (filter.MaxRating.HasValue)
			{
				query = query.Where(m => m.Rating <= filter.MaxRating.Value);
			}

			// Tarih aralığı filtreleme
			if (filter.StartYear.HasValue)
			{
				query = query.Where(m => m.RelaseTime >= filter.StartYear.Value);
			}
			if (filter.EndYear.HasValue)
			{
				query = query.Where(m => m.RelaseTime <= filter.EndYear.Value);
			}

			var result = await query.Select(m => new ResultMovieDto
			{
				Id = m.Id,
				Title = m.Title,
				Description = m.Description,
				CategoryName = m.Category.CategoryName,
				Rating = m.Rating,
				RelaseTime = m.RelaseTime,
				CoverImageUrl = m.CoverImageUrl
			}).ToListAsync();

			return result;
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
