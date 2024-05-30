using Education.Application.UseCases.UserCases.Commands;
using Education.Application.UseCases.UserCases.Queries;
using Education.Application.UseCases.WishListCases.Queries;
using Education.Domain.Entities;
using Education.Domain.Entities.Auth;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Education.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public UserController(IMediator mediator)
        {
            _mediatr = mediator;
        }
        [HttpGet]
      //  [Authorize(Roles ="Admin")]
        public async Task<List<UserModel>> GetAllUsers()
        {
            var res = await _mediatr.Send(new GetAllUsersQuery());
            return res;
        }
        [HttpGet]
        public async Task<List<CourseModel>> GetUserCourses(string useId)
        {
            return await _mediatr.Send(new GetUserCoursesCommand() { UserId = useId});
        }
        [HttpGet]
       // [Authorize(Roles = "Admin")]
        public async Task<UserModel> GetUserById(Guid id)
        {
            var res = await _mediatr.Send(new GetUserByIdQuery() { Id = id });
            return res;
        }
        [HttpPost]
        public async Task<ResponseModel> AddExp(AddExpCommand command)
        {
            return await _mediatr.Send(command);
        }
        [HttpPut ]
        public async Task<ResponseModel> UpdateUser([FromForm] UpdateUserCommand command)
        {
            var res = await _mediatr.Send(command);
            return res;
        }
        [HttpDelete]
        public async Task<ResponseModel> DeleteUser(Guid id)
        {
            var res = await _mediatr.Send( new DeleteUserCommand(){ Id = id});
            return res;
        }
        [HttpGet]
        public async Task<ResponseModel> BuyCourse(string UserId,Guid CourseId)
        {
            return await _mediatr.Send(new BuyCourseCommand() { UserId = UserId,CourseId = CourseId });
        }
        [HttpGet]
        public async Task<List<CourseModel>> GetCoursesFromWishList(string userId)
        {
            return await _mediatr.Send(new GetAllCourseFromWishListQuery() { UserId = userId});
        }
    }
}