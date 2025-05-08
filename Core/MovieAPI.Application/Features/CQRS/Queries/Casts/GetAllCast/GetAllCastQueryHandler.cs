using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Application.Dtos.Cast;
using MovieAPI.Application.Repositories.Cast;

namespace MovieAPI.Application.Features.CQRS.Queries.Casts.GetAllCast
{
	public class GetAllCastQueryHandler : IRequestHandler<GetAllCastQuery, GetAllCastQueryResponse>
	{
		private readonly ICastReadRepository _readRepository;

		public GetAllCastQueryHandler(ICastReadRepository readRepository)
		{
			_readRepository = readRepository;
		}

		public async Task<GetAllCastQueryResponse> Handle(GetAllCastQuery request, CancellationToken cancellationToken)
		{
			var casts = await _readRepository.GetAll().ToListAsync();

			var castDtos = casts.Select(x => new GetAllCastDto
			{
				Name = request.Name,
				Surname = request.Surname,
				Title = request.Title,
				Biography = request.Biography,
				ImageUrl = request.ImageUrl,
				Overview = request.Overview
			}).ToList();

			return new()
			{
				Casts = castDtos
			};
		}
	}
}
