using JokeGenerator.UI.ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;

namespace JokeGenerator.UI.ConsoleApp
{
	public class ConsoleReader : IConsoleReader
	{
		#region Fields

		private readonly IConsolePrinter _consolePrinter;

		#endregion Fields

		#region Constructors

		public ConsoleReader(IConsolePrinter consolePrinter)
		{
			_consolePrinter = consolePrinter;
		}

		#endregion Constructors

		#region Methods

		public bool ReadKeyWithCondition(string message, ConsoleKey conditionKey, bool startBreakLine = false, bool endBreakLine = false)
		{
			_consolePrinter.PrintValue(message, startBreakLine, endBreakLine);
			return Console.ReadKey().Key == conditionKey;
		}

		public string ReadLine(string message, bool startBreakLine = false, bool endBreakLine = false)
		{
			_consolePrinter.PrintValue(message, startBreakLine, endBreakLine);
			return Console.ReadLine();
		}

		public ConsoleKey ReadKey(List<string> messages)
		{
			_consolePrinter.PrintValue(messages, "{0}");
			return Console.ReadKey().Key;
		}

		#endregion Methods
	}
}