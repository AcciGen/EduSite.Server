using Education.Application.UseCases.CourseCases.Cammands;
using Education.Application.UseCases.CourseCases.Queries;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public CourseController(IMediator mediator)
        {
            _mediatr = mediator;
        }
        [HttpGet]
        public async Task<List<CourseModel>> GetAllCourses()
        {
            var res = await _mediatr.Send(new GetAllCourseQuery());
            return res;
        }
        [HttpGet]
        public async Task<CourseModel> GetCourseById(Guid id)
        {
            CourseModel res = await _mediatr.Send(new GetCourseByIdQuery { Id=id});
            return res;
        }
        [HttpGet]
        public async Task<List<CourseModel>> GetCourseByTeacherName(string teacherName)
        {
            var res = await _mediatr.Send(new GetCourseByTeacherNameQuery() { TeacherName = teacherName});
            return res;
        }
        [HttpGet]
        public async Task<List<CourseModel>> GetCourseByLanguage(string language)
        {
            var res = await _mediatr.Send(new GetCourseByLanguageQuery() { Language = language });
            return res;
        }
        [HttpPost]
        public async Task<ResponseModel> CreateCourse(CreateCourseCommand command)
        {
            return await _mediatr.Send(command);

        }
        [HttpPut]
        public async Task<ResponseModel> UpdateCourse(UpdateCourseCommand command)
        {
            return await _mediatr.Send(command);

        }
        [HttpDelete]
        public async Task<ResponseModel> DeleteCourse(DeleteCourseCommand command)
        {
           return await _mediatr.Send(command);
            
        }
    }
}