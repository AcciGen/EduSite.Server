using Education.Application.UseCases.GroupCases.Commands;
using Education.Application.UseCases.GroupCases.Queries;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public GroupController(IMediator mediator)
        {
            _mediatr = mediator;
        }

        [HttpGet]
        public async Task<List<GroupModel>> GetAllGroups()
        {
            return await _mediatr.Send(new GetAllGroupsQuery());
        }
        [HttpGet]
        public async Task<GroupModel> GetGroupById (Guid courseId)
        {
            return await _mediatr.Send(new GetGroupsByIdQuery { CourseId =  courseId });
        }
        [HttpDelete]
        public async Task<ResponseModel> DeleteGroup(Guid id)
        {
            return await _mediatr.Send(new DeleteGroupCommand() { Id = id });
        }
        [HttpPut]
        public async Task<ResponseModel> UpdateGroup(UpdateGroupCommand command)
        {
            return await _mediatr.Send(new UpdateGroupCommand() { CourseId= command.CourseId });
        }
    }
}