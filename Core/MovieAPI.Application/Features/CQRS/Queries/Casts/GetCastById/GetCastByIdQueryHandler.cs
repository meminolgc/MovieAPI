using MediatR;
using MovieAPI.Application.Repositories.Cast;

namespace MovieAPI.Application.Features.CQRS.Queries.Casts.GetCastById
{
	public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResponse>
	{
		private readonly ICastReadRepository _castReadRepository;

		public GetCastByIdQueryHandler(ICastReadRepository castReadRepository)
		{
			_castReadRepository = castReadRepository;
		}

		public async Task<GetCastByIdQueryResponse> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
		{
			var cast = await _castReadRepository.GetByIdAsync(request.Id);

			return new()
			{
				Id = cast.Id,
				Biography = cast.Biography,
				Name = cast.Name,
				Surname = cast.Surname,
				ImageUrl = cast.ImageUrl,
				Overview = cast.Overview,
				Title = cast.Title
			};
		}
	}
}
