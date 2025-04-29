using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieAPI.Persistence.Contexts;

namespace MovieAPI.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<MovieAPIDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
		}

	}
}
