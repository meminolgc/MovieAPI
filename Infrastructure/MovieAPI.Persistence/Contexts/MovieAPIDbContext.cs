using Microsoft.EntityFrameworkCore;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Persistence.Contexts
{
	public class MovieAPIDbContext : DbContext
	{
		public MovieAPIDbContext(DbContextOptions options) : base(options)
		{ }

		public DbSet<Category> Categories { get; set; }
		public DbSet<Movie> Movies { get; set; }
		public DbSet<Review> Reviews { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<Cast> Casts { get; set; }

	}
}
