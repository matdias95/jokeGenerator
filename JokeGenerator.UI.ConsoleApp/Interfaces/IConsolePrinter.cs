using System.Collections.Generic;

namespace JokeGenerator.UI.ConsoleApp.Interfaces
{
	public interface IConsolePrinter
	{
		#region Methods

		void PrintValue(string value, bool startBreakLine = false, bool endBreakLine = false);

		void PrintValue(IEnumerable<string> values, string format = "-------{0}");

		#endregion Methods
	}
}