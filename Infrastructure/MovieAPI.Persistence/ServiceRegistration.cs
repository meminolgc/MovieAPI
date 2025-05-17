using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieAPI.Application.Abstractions.Services;
using MovieAPI.Application.Repositories.Cast;
using MovieAPI.Application.Repositories.Category;
using MovieAPI.Application.Repositories.Movie;
using MovieAPI.Application.Repositories.Review;
using MovieAPI.Application.Repositories.Tag;
using MovieAPI.Persistence.Contexts;
using MovieAPI.Persistence.Repositories.Cast;
using MovieAPI.Persistence.Repositories.Category;
using MovieAPI.Persistence.Repositories.Movie;
using MovieAPI.Persistence.Repositories.Review;
using MovieAPI.Persistence.Repositories.Tag;
using MovieAPI.Persistence.Services;

namespace MovieAPI.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<MovieAPIDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

			services.AddScoped<ICastReadRepository, CastReadRepository>();
			services.AddScoped<ICastWriteRepository, CastWriteRepository>();

			services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
			services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

			services.AddScoped<IMovieReadRepository, MovieReadRepository>();
			services.AddScoped<IMovieWriteRepository, MovieWriteRepository>();

			services.AddScoped<IReviewReadRepository, ReviewReadRepository>();
			services.AddScoped<IReviewWriteRepository, ReviewWriteRepository>();

			services.AddScoped<ITagReadRepository, TagReadRepository>();
			services.AddScoped<ITagWriteRepository, TagWriteRepository>();

			services.AddScoped<IMovieService, MovieService>();
		}

	}
}
