using Education.Application.UseCases.LessonCase.Commands;
using Education.Application.UseCases.LessonCase.Queries;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public LessonController(IMediator mediator)
        {
            _mediatr = mediator;
        }

        [HttpGet]
        public async Task<List<LessonModel>> GetAllLessons(Guid courseId)
        {
           return await _mediatr.Send(new GetAllLessonsQuery() { CourseId =courseId });
        }
        [HttpGet]
        public async Task<LessonModel> GetLessonById(Guid id)
        {
            return await _mediatr.Send(new GetByIdLessonQuery() { Id = id });
        }
        [HttpGet]
        public async Task<LessonModel> GetLessonByTitle(string title)
        {
            return await _mediatr.Send(new GetByTitleLessonQuery() { Title = title });
        }
        [HttpPost]
        public async Task<ResponseModel> CreateLesson([FromForm] CreateLessonCommand command)
        {
            return await _mediatr.Send(command);
        }
        [HttpDelete]
        public async Task<ResponseModel> DeleteLesson(Guid id)
        {
            return await _mediatr.Send(new DeleteLessonCommand() { Id = id });
        }
        [HttpPut]
        public async Task<ResponseModel> UpdateLesson(UpdateLessonCommand command)
        {
            return await _mediatr.Send(command);
        }
    }
}
