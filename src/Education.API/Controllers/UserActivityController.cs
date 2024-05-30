using Education.Application.UseCases.UserActivityCase.Commands;
using Education.Application.UseCases.UserActivityCase.Queries;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserActivityController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public UserActivityController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<UserActivityModel> GetUserActivity(Guid id)
        {
            return await _mediatr.Send(new GetUserActivityQuery { Id = id });
            
        }

        [HttpGet]
        public async Task<List<UserActivityModel>>GetAllUsersActivity(string id)
        {
           return await _mediatr.Send(new GetAllUsersActivityQuery() { UserId = id });
        }

        [HttpPost]
        public async Task<ResponseModel> AddUserActivity(CreateUserActivityCommand command)
        {
            return await _mediatr.Send(command);
            
        }

        [HttpPut]
        public async Task<ResponseModel> UpdateUserActivity(UpdateUserActivityCommand command)
        {
            return await _mediatr.Send(command);
        }

        [HttpDelete]
        public async Task<ResponseModel> DeleteUserActivity(Guid ActivityId)
        {
            return await _mediatr.Send(new DeleteUserActivityCommand() { Id = ActivityId});
        }


    }
}
