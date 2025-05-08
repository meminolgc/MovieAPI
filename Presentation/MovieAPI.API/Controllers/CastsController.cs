using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Application.Features.CQRS.Commands.Casts.CreateCast;
using MovieAPI.Application.Features.CQRS.Commands.Casts.RemoveCast;
using MovieAPI.Application.Features.CQRS.Commands.Casts.UpdateCast;
using MovieAPI.Application.Features.CQRS.Queries.Casts.GetAllCast;
using MovieAPI.Application.Features.CQRS.Queries.Casts.GetCastById;

namespace MovieAPI.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CastsController : ControllerBase
	{
		readonly IMediator _mediator;

		public CastsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("{Id}")]
		public async Task<IActionResult> GetCastById([FromRoute] GetCastByIdQuery getCastByIdQuery)
		{
			GetCastByIdQueryResponse response = await _mediator.Send(getCastByIdQuery);
			return Ok(response);
		}

		[HttpGet("GetAllCasts")]
		public async Task<IActionResult> GetAllCasts()
		{
			var result = await _mediator.Send(new GetAllCastQuery());
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> AddCast(CreateCastCommand createCastCommand)
		{
			CreateCastCommandResponse response = await _mediator.Send(createCastCommand);
			return Ok(response);
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveCast(RemoveCastCommand removeCastCommand)
		{
			RemoveCastCommandResponse response = await _mediator.Send(removeCastCommand);
			return Ok(response);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateCast(UpdateCastCommand updateCastCommand)
		{
			UpdateCastCommandResponse response = await _mediator.Send(updateCastCommand);
			return Ok();
		}
	}
}
