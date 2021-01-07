using JokeGenerator.Handlers.Responses;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace JokeGenerator.UI.Jokes
{
	public class ViewModel : INotifyPropertyChanged
	{
		public bool IsLoading { get; set; } = true;

		public ObservableCollection<Joke> Jokes { get; set; } = new ObservableCollection<Joke>();

		public event PropertyChangedEventHandler PropertyChanged;
	}
}