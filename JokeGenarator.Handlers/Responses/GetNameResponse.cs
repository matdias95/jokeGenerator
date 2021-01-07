using Newtonsoft.Json;

namespace JokeGenerator.Handlers.Responses
{
	public class GetNameResponse
	{
		#region Properties

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("surname")]
		public string Surname { get; set; }

		#endregion Properties
	}
}