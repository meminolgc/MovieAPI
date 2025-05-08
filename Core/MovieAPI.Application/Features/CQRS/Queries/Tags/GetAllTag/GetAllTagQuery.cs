using MediatR;

namespace MovieAPI.Application.Features.CQRS.Queries.Tags.GetAllTag
{
	public class GetAllTagQuery : IRequest<GetAllTagQueryResponse>
	{
		public int Id { get; set; }
		public string Title { get; set; }
	}
}
