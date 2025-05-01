using MediatR;

namespace MovieAPI.Application.Features.CQRS.Queries.Movies.GetByIdMovie
{
	public class GetByIdMovieQueryHandler : IRequestHandler<GetByIdMovieQuery, GetByIdMovieQueryResponse>
	{
		public Task<GetByIdMovieQueryResponse> Handle(GetByIdMovieQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
