using JokeGenarator.Handlers;
using JokeGenerator.UI.ConsoleApp.Interfaces;
using JokerGenerator.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Threading.Tasks;

namespace JokeGenerator.UI.ConsoleApp
{
	internal class Program
	{
		#region Methods

		public static async Task Main(string[] args)
		{
			var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

			var configuration = builder.Build();

			var serviceCollection = new ServiceCollection();
			ConfigureServices(serviceCollection, configuration);

			var serviceProvider = serviceCollection.BuildServiceProvider();

			var jokeGenerator = serviceProvider.GetRequiredService<JokeGenerator>();
			await jokeGenerator.Run();
		}

		private static void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
		{
			services
				.AddScoped(typeof(JokeGenerator))
				.AddTransient<IConsolePrinter, ConsolePrinter>()
				.AddTransient<IConsoleReader, ConsoleReader>()
				.RegisterHandlers()
				.RegisterConfiguration(configuration);
		}

		#endregion Methods
	}
}