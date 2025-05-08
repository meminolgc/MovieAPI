using MovieAPI.Domain.Entities.Common;

namespace MovieAPI.Domain.Entities
{
	public class Movie : BaseEntity
	{
		public string Title { get; set; }
		public string? Description { get; set; }
		public string? CoverImageUrl { get; set; }
		public string? CreatedYear { get; set; }
		public decimal Rating { get; set; }
		public int Duration { get; set; }
		public bool Status { get; set; }
		public DateTime RelaseTime { get; set; }

		public int CategoryId { get; set; }
		public Category Category { get; set; }
	}
}
