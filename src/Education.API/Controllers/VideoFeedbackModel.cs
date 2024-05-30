using Education.Application.UseCases.VideoFeedbackCases.Commands;
using Education.Application.UseCases.VideoFeedbackCases.Queries;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VideoFeedbackModel : ControllerBase
    {
        private readonly IMediator _mediatr;
        public VideoFeedbackModel(IMediator mediator)
        {
            _mediatr = mediator;
        }
        [HttpGet]
        public async Task<List<Education.Domain.Entities.VideoFeedbackModel>> GetAllFeedbacks(Guid VideoId)
        {
            return await _mediatr.Send(new GetAllVideoFeedbacksQuery { VideoId = VideoId });
        }
        [HttpPost]
        public async Task<ResponseModel> CreateFeedBack (CreateVideoFeedbackCommand command)
        {
            return await _mediatr.Send(command);
        }
        [HttpPut]
        public async Task<ResponseModel> UpdateVideoFeedback(UpdateVideoFeedbackCommand command)
        {
            var res = await _mediatr.Send(command);
            return new ResponseModel()
            {
                Message = "Succesfully updated",
                StatusCode = 201,
                IsSuccess = true
            };
        }
        [HttpDelete]
        public async Task<ResponseModel> DeleteVideoFeedback(Guid id)
        {
            await _mediatr.Send(new DeleteVideoFeedbackCommand { Id = id });

            return new ResponseModel()
            {
                Message = "Succesfully deleted",
                StatusCode = 201,
                IsSuccess = true
            };
        }
    }
}
