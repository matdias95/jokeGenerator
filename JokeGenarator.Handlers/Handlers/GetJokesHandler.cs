using JokeGenerator.Handlers.Requests;
using JokeGenerator.Handlers.Responses;
using JokeGenerator.Services.Interfaces;
using JokerGenerator.Configuration;
using MediatR;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace JokeGenerator.Handlers.Handlers
{
	public class GetJokesHandler : IRequestHandler<GetJokesRequest, IEnumerable<Joke>>
	{
		#region Fields

		private readonly IMediator _mediator;
		private readonly IHttpApiService _httpApiService;
		private readonly ApiSettings _apiSettings;

		#endregion Fields

		#region Constructors

		public GetJokesHandler(
			IMediator mediator,
			IHttpApiService httpApiService,
			IOptions<ApiSettings> apiSettings)
		{
			_mediator = mediator;
			_httpApiService = httpApiService;
			_apiSettings = apiSettings.Value;
		}

		#endregion Constructors

		#region Methods

		public async Task<IEnumerable<Joke>> Handle(GetJokesRequest request, CancellationToken cancellationToken)
		{
			var uriBuilder = new UriBuilder(_apiSettings.ChuckNorrisApi);
			uriBuilder.Path += "random";
			var url = uriBuilder.Uri.ToString();

			if (!string.IsNullOrEmpty(request.Category))
			{
				url = QueryHelpers.AddQueryString(url, new Dictionary<string, string>() { { "category", request.Category.ToLower() } });
			}

			return await GetJokes(url, request);
		}

		private async Task<string> GetName(GetJokesRequest request)
		{
			if (!request.RandonName) return null;

			var response = await _mediator.Send(new GetNameRequest());

			return !string.IsNullOrEmpty(response.Surname) ? $"{response.Name} {response.Surname}" : response.Name;
		}

		private async Task<IEnumerable<Joke>> GetJokes(string url, GetJokesRequest request)
		{
			var jokes = new List<Joke>();
			var name = await GetName(request);

			while (jokes.Count() < request.TotalJokes)
			{
				var joke = await _httpApiService.GetAsync<Joke>(url);
				PrepareValue(name, joke);
				jokes.Add(joke);
			}

			return jokes.ToArray();
		}

		private void PrepareValue(string name, Joke joke)
		{
			if (string.IsNullOrEmpty(name)) return;

			var pattern = @"\bChuck Norris\b";

			joke.Value = Regex.Replace(joke.Value, pattern, name);
		}

		#endregion Methods
	}
}