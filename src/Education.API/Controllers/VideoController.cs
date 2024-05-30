using Education.Application.UseCases.VideoCases.Command;
using Education.Application.UseCases.VideoCases.Queries;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public VideoController(IMediator mediator)
        {
            _mediatr = mediator;
        }

        [HttpGet]
        public async Task<List<VideoModel>> GetAllVideos(Guid courseId)
        {
            return await _mediatr.Send(new GetAllVideosByCourseIdQuery() { CourseId = courseId});
        }
        [HttpGet]
        public async Task<VideoModel> GetVideoByLessonId(Guid lessonId)
        {
            return await _mediatr.Send(new GetVideoByLessonIdQuery() { LessonId = lessonId });
        }
       
        [HttpDelete]
        public async Task<ResponseModel> DeleteVideo(Guid lessonId)
        {
            return await _mediatr.Send(new DeleteVideoCommand() { LessonId = lessonId }); ;
        }
    }
}
