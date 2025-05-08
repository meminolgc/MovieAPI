namespace MovieAPI.Application.Features.CQRS.Commands.Casts.CreateCast
{
	public class CreateCastCommandResponse
	{
		public int Id { get; set; }
		public bool Success { get; set; }
		public string? Message { get; set; }
	}
}
