using MediatR;

namespace MovieAPI.Application.Features.CQRS.Queries.Movies.GetByIdMovie
{
	public class GetByIdMovieQuery : IRequest<GetByIdMovieQueryResponse>
	{
		public int MovieId { get; set; }
	}
}
