using MovieAPI.Domain.Entities.Common;

namespace MovieAPI.Domain.Entities
{
	public class RelatedMovie : BaseEntity
	{
		public int MovieId { get; set; }
		public int RelatedMovieId { get; set; }
		public int UserId { get; set; }
		public bool IsWatch { get; set; }
	}
}
