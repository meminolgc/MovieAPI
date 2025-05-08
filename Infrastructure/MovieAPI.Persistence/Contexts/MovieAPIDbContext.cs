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

		protected override void OnModelCreating(ModelBuilder builder)
		{
			// Movie ve Category arasında bire bir ilişki kuruyoruz
			builder.Entity<Movie>()
				.HasKey(m => m.Id); // Movie'nin birincil anahtarını tanımlıyoruz

			builder.Entity<Category>()
				.HasKey(c => c.Id); // Category'nin birincil anahtarını tanımlıyoruz

			// Movie ve Category arasında bir ilişki kuruyoruz (Foreign Key)
			builder.Entity<Movie>()
				.HasOne(m => m.Category)  // Movie'nin bir Category'si var
				.WithMany(c => c.Movies)  // Category'nin birden çok Movie'si olabilir
				.HasForeignKey(m => m.CategoryId); // Movie'deki CategoryId dış anahtarını kullanıyoruz

			base.OnModelCreating(builder);
		}

	}
}
