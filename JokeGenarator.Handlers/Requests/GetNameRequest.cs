using JokeGenerator.Handlers.Responses;
using MediatR;

namespace JokeGenerator.Handlers.Requests
{
	public class GetNameRequest : IRequest<GetNameResponse>
	{
	}
}