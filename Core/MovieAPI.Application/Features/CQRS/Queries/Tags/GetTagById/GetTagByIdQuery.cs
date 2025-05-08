using MediatR;

namespace MovieAPI.Application.Features.CQRS.Queries.Tags.GetTagById
{
	public class GetTagByIdQuery : IRequest<GetTagByIdQueryResponse>
	{
		public int Id { get; set; }
	}
}
