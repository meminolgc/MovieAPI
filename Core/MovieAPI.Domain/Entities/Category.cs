using MovieAPI.Domain.Entities.Common;

namespace MovieAPI.Domain.Entities
{
	public class Category : BaseEntity
	{
		public string CategoryName { get; set; }
		public ICollection<Movie> Movies { get; set; }
	}
}
