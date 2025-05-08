using MediatR;
using MovieAPI.Application.Repositories.Cast;

namespace MovieAPI.Application.Features.CQRS.Commands.Casts.CreateCast
{
	public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand, CreateCastCommandResponse>
	{
		private readonly ICastWriteRepository _castWriteRepository;

		public CreateCastCommandHandler(ICastWriteRepository castWriteRepository)
		{
			_castWriteRepository = castWriteRepository;
		}

		public async Task<CreateCastCommandResponse> Handle(CreateCastCommand request, CancellationToken cancellationToken)
		{
			Domain.Entities.Cast cast = await _castWriteRepository.AddAsync(new Domain.Entities.Cast
			{
				Biography = request.Biography,
				ImageUrl = request.ImageUrl,
				Name = request.Name,
				Surname = request.Surname,
				Overview = request.Overview,
				Title = request.Title
			});
			await _castWriteRepository.SaveAsync();

			return new()
			{
				Id = cast.Id,
				Success = true,
				Message = "Cast created successfully."
			};
		}
	}
}
