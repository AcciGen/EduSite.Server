using Education.Application.UseCases.QuestionCase.Commands;
using Education.Application.UseCases.QuestionCase.Queries;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public QuestionController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async Task<ResponseModel> CreateQuestion(CreateQuestionCommand command)
        {
            return await _mediatr.Send(command);
        }

        [HttpPut]
        public async Task<ResponseModel> UpdateQuestion(UpdateQuestionCommand command)
        {
            return await _mediatr.Send(command);
        }

        [HttpDelete]
        public async Task<ResponseModel> DeleteQuestion(DeleteQuestionCommand command)
        {
            return await _mediatr.Send(command);
          
        }

        [HttpGet]
        public async Task<List<QuestionModel>> GetAllQuestions()
        {
            return await _mediatr.Send(new GetAllQuestionsQuery());
            
        }

        [HttpGet("{id}")]
        public async Task<QuestionModel> GetQuestionById(Guid id)
        {
            return await _mediatr.Send(new GetQuestionByIdQuery() { Id = id });
            
        }
    }
}