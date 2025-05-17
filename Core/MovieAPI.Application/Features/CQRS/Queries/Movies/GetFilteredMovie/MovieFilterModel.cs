namespace MovieAPI.Application.Features.CQRS.Queries.Movies.GetFilteredMovie
{
	public class MovieFilterModel
	{
		public string? Title { get; set; }
		public List<int>? CategoryIds { get; set; } 
		public decimal? MinRating { get; set; }
		public decimal? MaxRating { get; set; }
		public DateTime? StartYear { get; set; }
		public DateTime? EndYear { get; set; }
	}
}
