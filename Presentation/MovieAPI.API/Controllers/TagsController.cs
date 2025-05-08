using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Application.Features.CQRS.Commands.Tags.CreateTag;
using MovieAPI.Application.Features.CQRS.Commands.Tags.RemoveTag;
using MovieAPI.Application.Features.CQRS.Commands.Tags.UpdateTag;
using MovieAPI.Application.Features.CQRS.Queries.Tags.GetAllTag;
using MovieAPI.Application.Features.CQRS.Queries.Tags.GetTagById;

namespace MovieAPI.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TagsController : ControllerBase
	{
		readonly IMediator _mediator;

		public TagsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("{Id}")]
		public async Task<IActionResult> GetTagById([FromRoute] GetTagByIdQuery getTagByIdQuery)
		{
			GetTagByIdQueryResponse response = await _mediator.Send(getTagByIdQuery);
			return Ok(response);
		}

		[HttpGet("GetAllTags")]
		public async Task<IActionResult> GetAllTags()
		{
			var result = await _mediator.Send(new GetAllTagQuery());
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> AddTag(CreateTagCommand createTagCommand)
		{
			CreateTagCommandResponse response = await _mediator.Send(createTagCommand);
			return Ok(response);
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveTag(RemoveTagCommand removeTagCommand)
		{
			RemoveTagCommandResponse response = await _mediator.Send(removeTagCommand);
			return Ok(response);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateTag(UpdateTagCommand updateTagCommand)
		{
			UpdateTagCommandResponse response = await _mediator.Send(updateTagCommand);
			return Ok();
		}
	}
}
