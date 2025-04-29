using MovieAPI.Domain.Entities.Common;

namespace MovieAPI.Domain.Entities
{
	public class Review : BaseEntity
	{
		public string? ReviewComment { get; set; }
		public int UserRating { get; set; }
		public bool Status { get; set; }
		public DateTime ReviewDate { get; set; }
	}
}
