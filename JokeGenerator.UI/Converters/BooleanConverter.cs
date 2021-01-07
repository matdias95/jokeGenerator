using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace JokeGenerator.UI.Converters
{
	public class BooleanConverter<T> : IValueConverter
	{
		#region Properties

		public T True { get; set; }
		public T False { get; set; }

		#endregion Properties

		#region Constructors

		public BooleanConverter(T trueValue, T falseValue)
		{
			True = trueValue;
			False = falseValue;
		}

		#endregion Constructors

		#region Methods

		public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value is bool && ((bool)value) ? True : False;
		}

		public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value is T && EqualityComparer<T>.Default.Equals((T)value, True);
		}

		#endregion Methods
	}
}