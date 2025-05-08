using MediatR;

namespace MovieAPI.Application.Features.CQRS.Queries.Casts.GetCastById
{
	public class GetCastByIdQuery : IRequest<GetCastByIdQueryResponse>
	{
		public int Id { get; set; }
	}
}
