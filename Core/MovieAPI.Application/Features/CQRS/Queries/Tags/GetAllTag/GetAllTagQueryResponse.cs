using MovieAPI.Application.Dtos.Tag;

namespace MovieAPI.Application.Features.CQRS.Queries.Tags.GetAllTag
{
	public class GetAllTagQueryResponse
	{
		public List<GetAllTagDto> Tags { get; set; }
	}
}
