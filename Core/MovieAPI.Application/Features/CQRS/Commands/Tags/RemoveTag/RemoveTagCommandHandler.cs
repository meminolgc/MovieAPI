using MediatR;
using MovieAPI.Application.Repositories.Tag;

namespace MovieAPI.Application.Features.CQRS.Commands.Tags.RemoveTag
{
	public class RemoveTagCommandHandler : IRequestHandler<RemoveTagCommand, RemoveTagCommandResponse>
	{
		private readonly ITagWriteRepository _tagWriteRepository;

		public RemoveTagCommandHandler(ITagWriteRepository tagWriteRepository)
		{
			_tagWriteRepository = tagWriteRepository;
		}

		public async Task<RemoveTagCommandResponse> Handle(RemoveTagCommand request, CancellationToken cancellationToken)
		{
			await _tagWriteRepository.RemoveAsync(request.Id);
			await _tagWriteRepository.SaveAsync();

			return new();
		}
	}
}
