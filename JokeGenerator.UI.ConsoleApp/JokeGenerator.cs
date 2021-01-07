using JokeGenerator.Handlers.Requests;
using JokeGenerator.UI.ConsoleApp.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokeGenerator.UI.ConsoleApp
{
	public class JokeGenerator
	{
		#region Fields

		private readonly IMediator _mediator;
		private readonly IConsolePrinter _consolePrinter;
		private readonly IConsoleReader _consoleReader;
		private IEnumerable<string> categories;
		private string category;
		private int totalJokes;

		#endregion Fields

		#region Constructors

		public JokeGenerator(IMediator mediator, IConsolePrinter consolePrinter, IConsoleReader consoleReader)
		{
			_mediator = mediator;
			_consolePrinter = consolePrinter;
			_consoleReader = consoleReader;
		}

		#endregion Constructors

		#region Methods

		public async Task Run()
		{
			var result = _consoleReader.ReadLine("Press ? to get instructions.");

			if (result.Equals("?"))
			{
				var exit = false;

				while (!exit)
				{
					var actionKey = _consoleReader.ReadKey(new List<string>() { "Press c to get categories", "Press r to get random jokes", "Press Esc to exit" });

					switch (actionKey)
					{
						case ConsoleKey.C:
							await GetCategories();
							break;

						case ConsoleKey.R:
							await GetJokes();
							break;

						case ConsoleKey.Escape:
							exit = true;
							break;
					}

					category = null;
				}

				_consolePrinter.PrintValue("Closing...");
			}
		}

		private async Task GetJokes()
		{
			var randomName = _consoleReader.ReadKeyWithCondition("Want to use a random name? y/n", ConsoleKey.Y, true);

			if (_consoleReader.ReadKeyWithCondition("Want to specify a category? y/n", ConsoleKey.Y, true))
			{
				var validCategory = false;

				if (categories == null || categories.Count() == 0) await GetCategories();

				while (!validCategory)
				{
					category = _consoleReader.ReadLine("Enter a category:", true);
					validCategory = ValidateCategory(category);

					if (!validCategory)
					{
						if (_consoleReader.ReadKeyWithCondition("Invalid category. Do you want to specify a category? y/n", ConsoleKey.N))
						{
							category = null;
							break;
						}
					}
				}
			}

			var validJokesNumber = false;

			while (!validJokesNumber)
			{
				var result = _consoleReader.ReadLine("How many jokes do you want? (1-9)", true);
				validJokesNumber = ValidateTotalJokes(result);

				if (!validJokesNumber)
				{
					_consolePrinter.PrintValue("Invalid number.", true);
				}
				else
				{
					totalJokes = Int32.Parse(result);
				}
			}

			await GetRandomJokes(new GetJokesRequest()
			{
				RandonName = randomName,
				Category = category,
				TotalJokes = totalJokes
			});
		}

		private bool ValidateCategory(string value)
		{
			return categories.Any(x => x.ToLower().Equals(value.ToLower()));
		}

		private bool ValidateTotalJokes(string value)
		{
			if (!Int32.TryParse(value, out int convertedValue)) return false;
			if (convertedValue < 1 || convertedValue > 9) return false;

			return true;
		}

		private async Task GetRandomJokes(GetJokesRequest request)
		{
			_consolePrinter.PrintValue("Generating jokes...", true);

			var jokes = await _mediator.Send(request);

			_consolePrinter.PrintValue(jokes.Select(x => x.Value).ToArray());
		}

		private async Task GetCategories()
		{
			_consolePrinter.PrintValue("Loading categories...", true);
			categories = await _mediator.Send(new GetCategoriesRequest());
			_consolePrinter.PrintValue(categories);
		}

		#endregion Methods
	}
}