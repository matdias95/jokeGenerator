using JokeGenerator.UI.ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JokeGenerator.UI.ConsoleApp
{
	public class ConsolePrinter : IConsolePrinter
	{
		#region Methods

		public void PrintValue(string value, bool startBreakLine = false, bool endBreakLine = false)
		{
			if (startBreakLine) Console.WriteLine();
			Console.WriteLine(value);
			if (endBreakLine) Console.WriteLine();
		}

		public void PrintValue(IEnumerable<string> values, string format)
		{
			Console.WriteLine();
			values.ToList().ForEach(x => PrintValue(string.Format(format, x)));
		}

		#endregion Methods
	}
}