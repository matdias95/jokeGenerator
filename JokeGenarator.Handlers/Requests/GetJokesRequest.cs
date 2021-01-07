using JokeGenerator.Handlers.Responses;
using MediatR;
using System.Collections.Generic;

namespace JokeGenerator.Handlers.Requests
{
	public class GetJokesRequest : IRequest<IEnumerable<Joke>>
	{
		#region Methods

		public bool RandonName { get; set; }

		public string Category { get; set; }

		public int TotalJokes { get; set; }

		#endregion Methods
	}
}