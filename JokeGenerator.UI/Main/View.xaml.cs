using JokeGenerator.Handlers.Requests;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace JokeGenerator.UI.Main
{
	public partial class View : Window
	{
		#region Fields

		private readonly IMediator _mediator;
		private readonly IServiceProvider _serviceProvider;

		#endregion Fields

		#region Properties

		public ViewModel Model { get; set; } = new ViewModel();

		#endregion Properties

		#region Constructors

		public View(IMediator mediator, IServiceProvider serviceProvider)
		{
			InitializeComponent();

			_mediator = mediator;
			_serviceProvider = serviceProvider;

			DataContext = Model;
		}

		#endregion Constructors

		#region Methods

		#region Event Handlers

		private void Generate_Jokes_Click(object sender, RoutedEventArgs e)
		{
			var view = _serviceProvider.GetRequiredService<Jokes.View>();
			view.Request = new GetJokesRequest()
			{
				Category = ComboBoxCategories.SelectedValue?.ToString(),
				RandonName = CheckBoxRandomName.IsChecked ?? false,
				TotalJokes = Model.TotalJokes
			};

			view.ShowDialog();
		}

		private void Clear_Options_Click(object sender, RoutedEventArgs e)
		{
			ComboBoxCategories.SelectedIndex = -1;
			CheckBoxRandomName.IsChecked = false;
			NumberBoxTotalJokes.Value = NumberBoxTotalJokes.Minimum;
		}

		private async void Window_Loaded(object sender, RoutedEventArgs e)
		{
			var categories = await _mediator.Send(new GetCategoriesRequest());

			Model.Categories = new ObservableCollection<string>(categories.Select(x => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(x)));
			Model.IsLoading = false;
		}

		#endregion Event Handlers

		#endregion Methods
	}
}