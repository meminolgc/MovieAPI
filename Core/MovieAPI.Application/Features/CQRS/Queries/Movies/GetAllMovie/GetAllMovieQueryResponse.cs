using MovieAPI.Application.Dtos.Movie;
using MovieAPI.Dto.DTOs.MovieDtos;

namespace MovieAPI.Application.Features.CQRS.Queries.Movies.GetAllMovie
{
	public class GetAllMovieQueryResponse
	{
		public List<ResultMovieDto> Movies { get; set; }

	}
}
