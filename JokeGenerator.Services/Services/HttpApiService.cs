using JokeGenerator.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace JokeGenerator.Services.Services
{
	public class HttpApiService : IHttpApiService
	{
		#region Fields

		private readonly HttpClient _httpClient;

		#endregion Fields

		#region Constructors

		public HttpApiService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		#endregion Constructors

		#region Methods

		public async Task<T> GetAsync<T>(string url)
		{
			var result = await _httpClient.GetStringAsync(url);

			return JsonConvert.DeserializeObject<T>(result);
		}

		#endregion Methods
	}
}