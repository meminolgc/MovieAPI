namespace MovieAPI.Application.Features.CQRS.Commands.Tags.CreateTag
{
	public class CreateTagCommandResponse
	{
		public int Id { get; set; }
		public bool Success { get; set; }
		public string? Message { get; set; }
	}
}
