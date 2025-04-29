using MovieAPI.Domain.Entities.Common;

namespace MovieAPI.Domain.Entities
{
	public class Cast : BaseEntity
	{
		public string Title { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string? ImageUrl { get; set; }
		public string? Overview { get; set; }
		public string? Biography { get; set; }
	}
}
