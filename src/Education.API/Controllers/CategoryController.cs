// CategoryController.cs
using Education.Application.UseCases.CategoryCases.Commands;
using Education.Application.UseCases.CategoryCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet] 
        public async Task<IActionResult> GetCategories()
        {
            var result = await _mediator.Send(new GetAllCategoryQuery());
            return Ok(result);
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> GetCategory(Guid id)
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery() { Id = id});
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
