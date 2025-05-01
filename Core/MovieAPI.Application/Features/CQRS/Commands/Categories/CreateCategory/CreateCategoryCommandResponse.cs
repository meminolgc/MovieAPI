namespace MovieAPI.Application.Features.CQRS.Commands.Categories.CreateCategory
{
	public class CreateCategoryCommandResponse
	{
		public int CategoryId { get; set; }
		public bool Success { get; set; }
		public string? Message { get; set; }
	}
}
