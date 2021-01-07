using JokeGenerator.Handlers.Requests;
using JokeGenerator.Handlers.Responses;
using MediatR;
using System.Collections.ObjectModel;
using System.Windows;

namespace JokeGenerator.UI.Jokes
{
	public partial class View : Window
	{
		#region Fields

		private readonly IMediator _mediator;

		#endregion Fields

		#region Properties

		public GetJokesRequest Request { get; set; } = new GetJokesRequest();

		internal ViewModel Model { get; private set; } = new ViewModel();

		#endregion Properties

		#region Constructors

		public View(IMediator mediator)
		{
			InitializeComponent();

			DataContext = Model;

			_mediator = mediator;
		}

		#endregion Constructors

		#region Event Handlers

		private async void Window_Loaded(object sender, RoutedEventArgs e)
		{
			var jokes = await _mediator.Send(Request);

			Model.Jokes = new ObservableCollection<Joke>(jokes);
			Model.IsLoading = false;
		}

		#endregion Event Handlers
	}
}