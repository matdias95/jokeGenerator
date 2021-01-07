using JokeGenerator.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace JokeGenarator.Handlers
{
	public static class Dependencies
	{
		#region Methods

		public static IServiceCollection RegisterHandlers(this IServiceCollection service)
		{
			return service
				.AddMediatR(typeof(Dependencies).Assembly)
				.RegisterServices();
		}

		#endregion Methods
	}
}