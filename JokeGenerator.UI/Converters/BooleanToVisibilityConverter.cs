using System.Windows;

namespace JokeGenerator.UI.Converters
{
	public sealed class BooleanToVisibilityConverter : BooleanConverter<Visibility>
	{
		#region Constructors

		public BooleanToVisibilityConverter() :
			base(Visibility.Visible, Visibility.Hidden)
		{ }

		#endregion Constructors
	}
}