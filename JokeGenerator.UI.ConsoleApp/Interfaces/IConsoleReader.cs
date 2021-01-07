using System;
using System.Collections.Generic;

namespace JokeGenerator.UI.ConsoleApp.Interfaces
{
	public interface IConsoleReader
	{
		#region Methods

		bool ReadKeyWithCondition(string message, ConsoleKey conditionKey, bool startBreakLine = false, bool endBreakLine = false);

		ConsoleKey ReadKey(List<string> messages);

		string ReadLine(string message, bool startBreakLine = false, bool endBreakLine = false);

		#endregion Methods
	}
}