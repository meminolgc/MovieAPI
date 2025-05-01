using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MovieAPI.Application
{
	public static class ServiceRegistration
	{
		public static void AddApplicationServices(this IServiceCollection services)
		{
			services.AddMediatR(typeof(ServiceRegistration));
		}
	}
}
