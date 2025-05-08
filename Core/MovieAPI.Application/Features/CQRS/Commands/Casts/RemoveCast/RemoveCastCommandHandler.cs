using MediatR;
using MovieAPI.Application.Repositories.Cast;

namespace MovieAPI.Application.Features.CQRS.Commands.Casts.RemoveCast
{
	public class RemoveCastCommandHandler : IRequestHandler<RemoveCastCommand, RemoveCastCommandResponse>
	{
		private readonly ICastWriteRepository _castWriteRepository;

		public RemoveCastCommandHandler(ICastWriteRepository castWriteRepository)
		{
			_castWriteRepository = castWriteRepository;
		}

		public async Task<RemoveCastCommandResponse> Handle(RemoveCastCommand request, CancellationToken cancellationToken)
		{
			await _castWriteRepository.RemoveAsync(request.Id);
			await _castWriteRepository.SaveAsync();

			return new();
		}
	}
}
