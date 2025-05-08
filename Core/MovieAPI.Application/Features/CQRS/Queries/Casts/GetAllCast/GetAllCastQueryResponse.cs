using MovieAPI.Application.Dtos.Cast;

namespace MovieAPI.Application.Features.CQRS.Queries.Casts.GetAllCast
{
	public class GetAllCastQueryResponse
	{
		public List<GetAllCastDto> Casts { get; set; }
	}
}
