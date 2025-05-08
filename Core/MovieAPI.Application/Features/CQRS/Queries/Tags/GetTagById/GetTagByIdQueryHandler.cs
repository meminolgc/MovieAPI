using MediatR;
using MovieAPI.Application.Repositories.Tag;

namespace MovieAPI.Application.Features.CQRS.Queries.Tags.GetTagById
{
	public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, GetTagByIdQueryResponse>
	{
		private readonly ITagReadRepository _tagReadRepository;

		public GetTagByIdQueryHandler(ITagReadRepository tagReadRepository)
		{
			_tagReadRepository = tagReadRepository;
		}

		public async Task<GetTagByIdQueryResponse> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
		{
			 var tag = await _tagReadRepository.GetByIdAsync(request.Id);

			return new()
			{
				Id = tag.Id,
				Title = tag.Title
			};
		}
	}
}
