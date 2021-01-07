using JokeGenarator.Handlers;
using JokerGenerator.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;

namespace JokeGenerator.UI
{
	public partial class App : Application
	{
		#region Properties

		public IServiceProvider ServiceProvider { get; private set; }

		public IConfiguration Configuration { get; private set; }

		#endregion Properties

		#region Methods

		protected override void OnStartup(StartupEventArgs e)
		{
			var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

			Configuration = builder.Build();

			var serviceCollection = new ServiceCollection();
			ConfigureServices(serviceCollection);

			ServiceProvider = serviceCollection.BuildServiceProvider();

			var mainWindow = ServiceProvider.GetRequiredService<Main.View>();
			mainWindow.Show();
		}

		private void ConfigureServices(IServiceCollection services)
		{
			services
				.AddTransient(typeof(Main.View))
				.AddTransient(typeof(Jokes.View))
				.RegisterHandlers()
				.RegisterConfiguration(Configuration);
		}

		#endregion Methods
	}
}