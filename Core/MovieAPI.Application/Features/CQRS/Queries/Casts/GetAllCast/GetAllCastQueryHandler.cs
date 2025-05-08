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
				Name = x.Name,
				Surname = x.Surname,
				Title = x.Title,
				Biography = x.Biography,
				ImageUrl = x.ImageUrl,
				Overview = x.Overview
			}).ToList();

			return new()
			{
				Casts = castDtos
			};
		}
	}
}
