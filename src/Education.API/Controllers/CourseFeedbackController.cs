using Education.Application.UseCases.CourseFeedbackCase.Commands;
using Education.Application.UseCases.CourseFeedbackCase.Queries;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseFeedbackController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CourseFeedbackController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<List<CourseFeedbackModel>> GetAllFeedbacks(Guid courseId)
        {
            return await _mediator.Send( new GetAllFeedbacksQuery(){ CourseId = courseId});
        }
        [HttpPost]
        public async Task<ResponseModel> CreateFeedback(CreateCourseFeedbackCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpPut]
        public async Task<ResponseModel> UpdateFeedback(UpdateCourseFeedbackCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpDelete]
        public async Task<ResponseModel> DeleteFeedback(DeleteCourseFeedbackCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
