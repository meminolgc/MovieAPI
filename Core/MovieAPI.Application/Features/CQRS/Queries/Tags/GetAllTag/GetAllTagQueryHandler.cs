using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Application.Dtos.Tag;
using MovieAPI.Application.Repositories.Tag;

namespace MovieAPI.Application.Features.CQRS.Queries.Tags.GetAllTag
{
	public class GetAllTagQueryHandler : IRequestHandler<GetAllTagQuery, GetAllTagQueryResponse>
	{
		private readonly ITagReadRepository _tagReadRepository;

		public GetAllTagQueryHandler(ITagReadRepository tagReadRepository)
		{
			_tagReadRepository = tagReadRepository;
		}

		public async Task<GetAllTagQueryResponse> Handle(GetAllTagQuery request, CancellationToken cancellationToken)
		{
			var tags = await _tagReadRepository.GetAll().ToListAsync();

			var tagData = tags.Select(x => new GetAllTagDto
			{
				Title = x.Title
			}).ToList();

			return new GetAllTagQueryResponse
			{
				Tags = tagData
			};

		}
	}
}
