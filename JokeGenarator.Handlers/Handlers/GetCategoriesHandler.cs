using JokeGenerator.Handlers.Requests;
using JokeGenerator.Services.Interfaces;
using JokerGenerator.Configuration;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JokeGenerator.Handlers.Handlers
{
	public class GetCategoriesHandler : IRequestHandler<GetCategoriesRequest, IEnumerable<string>>
	{
		#region Fields

		private readonly IHttpApiService _httpService;
		private readonly ApiSettings _apiSettings;

		#endregion Fields

		#region Constructors

		public GetCategoriesHandler(
			IHttpApiService httpService,
			IOptions<ApiSettings> apiSettings)
		{
			_httpService = httpService;
			_apiSettings = apiSettings.Value;
		}

		#endregion Constructors

		#region Methods

		public async Task<IEnumerable<string>> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
		{
			var uriBuilder = new UriBuilder(_apiSettings.ChuckNorrisApi);
			uriBuilder.Path += "categories";

			return await _httpService.GetAsync<IEnumerable<string>>(uriBuilder.Uri.ToString());
		}

		#endregion Methods
	}
}