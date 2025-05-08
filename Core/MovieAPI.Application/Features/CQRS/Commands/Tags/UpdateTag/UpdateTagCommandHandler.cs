using MediatR;
using MovieAPI.Application.Repositories.Tag;

namespace MovieAPI.Application.Features.CQRS.Commands.Tags.UpdateTag
{
	public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, UpdateTagCommandResponse>
	{
		private readonly ITagWriteRepository _tagWriteRepository;
		private readonly ITagReadRepository _tagReadRepository;

		public UpdateTagCommandHandler(ITagWriteRepository tagWriteRepository, ITagReadRepository tagReadRepository)
		{
			_tagWriteRepository = tagWriteRepository;
			_tagReadRepository = tagReadRepository;
		}

		public async Task<UpdateTagCommandResponse> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
		{
			Domain.Entities.Tag tag  = await _tagReadRepository.GetByIdAsync(request.Id);

			if (tag == null)
			{
				return new()
				{
					Message = "Tag not found",
					Success = false
				};
			}

			tag.Title = request.Title;

			await _tagWriteRepository.SaveAsync();
			return new()
			{
				Message = "Success",
				Success = true
			};
		}
	}
}
