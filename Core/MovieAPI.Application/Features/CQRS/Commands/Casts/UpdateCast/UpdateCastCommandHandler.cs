using MediatR;
using MovieAPI.Application.Repositories.Cast;

namespace MovieAPI.Application.Features.CQRS.Commands.Casts.UpdateCast
{
	public class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommand, UpdateCastCommandResponse>
	{
		private readonly ICastWriteRepository _castWriteRepository;
		private readonly ICastReadRepository _castReadRepository;

		public UpdateCastCommandHandler(ICastWriteRepository castWriteRepository, ICastReadRepository castReadRepository)
		{
			_castWriteRepository = castWriteRepository;
			_castReadRepository = castReadRepository;
		}

		public async Task<UpdateCastCommandResponse> Handle(UpdateCastCommand request, CancellationToken cancellationToken)
		{
			Domain.Entities.Cast cast = await _castReadRepository.GetByIdAsync(request.Id);
			if (cast == null)
			{
				return new()
				{
					Message = "Cast not found",
					Success = false
				};
			}

			cast.Name = request.Name;
			cast.Surname = request.Surname;
			cast.Overview = request.Overview;
			cast.Biography = request.Biography;
			cast.ImageUrl = request.ImageUrl;
			cast.Title = request.Title;

			await _castWriteRepository.SaveAsync();
			return new()
			{
				Message = "Success",
				Success = true
			};
		}
	}
}
