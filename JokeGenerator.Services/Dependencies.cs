using JokeGenerator.Services.Interfaces;
using JokeGenerator.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace JokeGenerator.Services
{
	public static class Dependencies
	{
		#region Methods

		public static IServiceCollection RegisterServices(this IServiceCollection services)
		{
			services
				.AddTransient<IHttpApiService, HttpApiService>()
				.AddHttpClient<IHttpApiService, HttpApiService>();

			return services;
		}

		#endregion Methods
	}
}