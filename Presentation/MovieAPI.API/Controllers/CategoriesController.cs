using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Application.Features.CQRS.Commands.Categories.CreateCategory;
using MovieAPI.Application.Features.CQRS.Commands.Categories.RemoveCategory;
using MovieAPI.Application.Features.CQRS.Commands.Categories.UpdateCategory;
using MovieAPI.Application.Features.CQRS.Queries.Categories.GetAllCategory;
using MovieAPI.Application.Features.CQRS.Queries.Categories.GetByIdCategory;

namespace MovieAPI.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		readonly IMediator _mediator;

		public CategoriesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("{Id}")]
		public async Task<IActionResult> GetCategoryById([FromRoute] GetByIdCategoryQuery getByIdCategoryQuery)
		{
			GetByIdCategoryQueryResponse response = await _mediator.Send(getByIdCategoryQuery);
			return Ok(response);
		}

		[HttpGet("GetAllCategories")]
		public async Task<IActionResult> GetAllCategories()
		{
			var result = await _mediator.Send(new GetAllCategoryQuery());
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> AddCategory(CreateCategoryCommand createCategoryCommand)
		{
			CreateCategoryCommandResponse response = await _mediator.Send(createCategoryCommand);
			return Ok(response);
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveCategory(RemoveCategoryCommand removeCategoryCommand)
		{
			RemoveCategoryCommandResponse response = await _mediator.Send(removeCategoryCommand);
			return Ok(response);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand updateCategoryCommand)
		{
			UpdateCategoryCommandResponse response = await _mediator.Send(updateCategoryCommand);
			return Ok();
		}
	}
}
