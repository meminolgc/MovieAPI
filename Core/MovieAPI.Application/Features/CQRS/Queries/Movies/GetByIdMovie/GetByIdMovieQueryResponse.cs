namespace MovieAPI.Application.Features.CQRS.Queries.Movies.GetByIdMovie
{
	public class GetByIdMovieQueryResponse
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string? Description { get; set; }
		public string? CoverImageUrl { get; set; }
		public string? CreatedYear { get; set; }
		public decimal Rating { get; set; }
		public int Duration { get; set; }
		public bool Status { get; set; }
		public DateTime RelaseTime { get; set; }
	}
}
