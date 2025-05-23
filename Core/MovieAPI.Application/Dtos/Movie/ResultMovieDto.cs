﻿namespace MovieAPI.Application.Dtos.Movie
{
	public class ResultMovieDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string? Description { get; set; }
		public string? CategoryName { get; set; }
		public string? CoverImageUrl { get; set; }
		public string? CreatedYear { get; set; }
		public decimal Rating { get; set; }
		public int Duration { get; set; }
		public int CategoryId { get; set; }
		public bool Status { get; set; }
		public DateTime RelaseTime { get; set; }
	}
}
