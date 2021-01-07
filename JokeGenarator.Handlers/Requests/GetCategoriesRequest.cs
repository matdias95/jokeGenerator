using MediatR;
using System.Collections.Generic;

namespace JokeGenerator.Handlers.Requests
{
	public class GetCategoriesRequest : IRequest<IEnumerable<string>>
	{
	}
}