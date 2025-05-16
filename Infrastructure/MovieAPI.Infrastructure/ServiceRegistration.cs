using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieAPI.Persistence;

namespace MovieAPI.Infrastructure
{
	public static class ServiceRegistration
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddPersistenceServices(configuration); 
			return services;
		}
	}
}
