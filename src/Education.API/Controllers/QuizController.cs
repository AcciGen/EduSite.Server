using Education.Application.UseCases.QuizCase.Commands;
using Education.Application.UseCases.QuizCase.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuizController : ControllerBase
    {

        private readonly IMediator _mediatr;

        public QuizController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuizzes()
        {
            var query = new GetAllQuizQuery();
            var result = await _mediatr.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuizById(Guid id)
        {
            var query = new GetByIdQuizQuery { Id = id };
            var result = await _mediatr.Send(query);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateQuiz(CreateQuizCommand command)
        {
            var result = await _mediatr.Send(command);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateQuiz(UpdateQuizCommand command)
        {
            var result = await _mediatr.Send(command);
            return Ok(result);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteQuiz(DeleteQuizCommand command)
        {
            var result = await _mediatr.Send(command);
            return Ok(result);
        }


    }
}
