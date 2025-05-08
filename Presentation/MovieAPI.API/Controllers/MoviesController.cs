using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Application.Features.CQRS.Commands.Movies.CreateMovie;
using MovieAPI.Application.Features.CQRS.Commands.Movies.RemoveMovie;
using MovieAPI.Application.Features.CQRS.Commands.Movies.UpdateMovie;
using MovieAPI.Application.Features.CQRS.Queries.Movies.GetAllMovie;
using MovieAPI.Application.Features.CQRS.Queries.Movies.GetByIdMovie;

namespace MovieAPI.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		readonly IMediator _mediator;

		public MoviesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("{Id}")]
		public async Task<IActionResult> GetMovieById([FromRoute] GetByIdMovieQuery query)
		{
			GetByIdMovieQueryResponse response = await _mediator.Send(query);
			return Ok(response);
		}

		[HttpGet("GetAllMovies")]
		public async Task<IActionResult> GetAllMovies()
		{
			var result = await _mediator.Send(new GetAllMovieQuery());
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> AddMovie(CreateMovieCommand createMovieCommand)
		{
			CreateMovieCommandResponse response = await _mediator.Send(createMovieCommand);
			return Ok(response);
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveCategory(RemoveMovieCommand removeMovieCommand)
		{
			RemoveMovieCommandResponse response = await _mediator.Send(removeMovieCommand);
			return Ok(response);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateMovie(UpdateMovieCommand updateMovieCommand)
		{
			UpdateMovieCommandResponse response = await _mediator.Send(updateMovieCommand);
			return Ok(response);
		}
	}
}
