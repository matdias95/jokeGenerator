using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JokerGenerator.Configuration
{
	public static class Dependencies
	{
		#region Methods

		public static IServiceCollection RegisterConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			return services
				.Configure<ApiSettings>(configuration.GetSection("ApiSettings"));
		}

		#endregion Methods
	}
}