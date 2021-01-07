using JokeGenerator.Handlers.Requests;
using JokeGenerator.Handlers.Responses;
using JokeGenerator.Services.Interfaces;
using JokerGenerator.Configuration;
using MediatR;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;

namespace JokeGenerator.Handlers.Handlers
{
	public class GetNamesHandler : IRequestHandler<GetNameRequest, GetNameResponse>
	{
		#region Properties

		private readonly IHttpApiService _httpService;
		private readonly ApiSettings _apiSettings;

		#endregion Properties

		#region Constructors

		public GetNamesHandler(
			IHttpApiService httpService,
			IOptions<ApiSettings> apiSettings)
		{
			_httpService = httpService;
			_apiSettings = apiSettings.Value;
		}

		#endregion Constructors

		#region Methods

		public async Task<GetNameResponse> Handle(GetNameRequest request, CancellationToken cancellationToken)
		{
			return await _httpService.GetAsync<GetNameResponse>(_apiSettings.NamesApi);
		}

		#endregion Methods
	}
}