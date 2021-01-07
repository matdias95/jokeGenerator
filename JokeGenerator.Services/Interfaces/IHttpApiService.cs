using System.Threading.Tasks;

namespace JokeGenerator.Services.Interfaces
{
	public interface IHttpApiService
	{
		#region Methods

		Task<T> GetAsync<T>(string url);

		#endregion Methods
	}
}