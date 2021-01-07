using System.Collections.ObjectModel;
using System.ComponentModel;

namespace JokeGenerator.UI.Main
{
	public class ViewModel : INotifyPropertyChanged
	{
		#region Events

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion Events

		#region Properties

		public bool IsLoading { get; set; } = true;

		public int TotalJokes { get; set; } = 1;

		public ObservableCollection<string> Categories { get; set; } = new ObservableCollection<string>();

		#endregion Properties
	}
}