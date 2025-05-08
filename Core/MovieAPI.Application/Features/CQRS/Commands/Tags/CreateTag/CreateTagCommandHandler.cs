using MediatR;
using MovieAPI.Application.Repositories.Tag;

namespace MovieAPI.Application.Features.CQRS.Commands.Tags.CreateTag
{
	public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, CreateTagCommandResponse>
	{
		private readonly ITagWriteRepository _tagWriteRepository;

		public CreateTagCommandHandler(ITagWriteRepository tagWriteRepository)
		{
			_tagWriteRepository = tagWriteRepository;
		}

		public async Task<CreateTagCommandResponse> Handle(CreateTagCommand request, CancellationToken cancellationToken)
		{
			var tag = await _tagWriteRepository.AddAsync(new Domain.Entities.Tag
			{
				Title = request.Title
			});

			await _tagWriteRepository.SaveAsync();

			return new()
			{
				Id = tag.Id,
				Success = true,
				Message = "Tag created successfully."
			};
		}
	}
}
