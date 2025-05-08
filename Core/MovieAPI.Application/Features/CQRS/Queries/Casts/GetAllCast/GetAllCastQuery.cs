using MediatR;

namespace MovieAPI.Application.Features.CQRS.Queries.Casts.GetAllCast
{
	public class GetAllCastQuery : IRequest<GetAllCastQueryResponse>
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string? ImageUrl { get; set; }
		public string? Overview { get; set; }
		public string? Biography { get; set; }
	}
}
