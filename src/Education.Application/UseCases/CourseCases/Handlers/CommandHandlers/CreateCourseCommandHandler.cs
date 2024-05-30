using Education.Application.Abstractions;
using Education.Application.UseCases.CourseCases.Cammands;
using Education.Application.UseCases.GroupCases.Commands;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CourseCases.Handlers.CommandHandlers
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;
        private readonly IMediator _mediator;

        public CreateCourseCommandHandler(IEducationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<ResponseModel> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = new CourseModel()
            {
                CourseName = request.CourseName,
                Description = request.Description,
                TotalTime = request.TotalTime,
                Price = request.Price,
                Language = request.Language,
                TeacherName = request.TeacherName,
                CouponId = request.CouponId,
                CategoryId = request.CategoryId,
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            var groupCommand = new CreateGroupCommand()
            {
                GroupName = request.CourseName,
                CourseId = course.Id 
            };

            var groupCreationResponse = await _mediator.Send(groupCommand);

            if (!groupCreationResponse.IsSuccess)
            {
                return new ResponseModel()
                {
                    Message = "Failed to create group for the course",
                    StatusCode = 500, 
                    IsSuccess = false
                };
            }

            return new ResponseModel()
            {
                Message = "Successfully Created",
                StatusCode = 201,
                IsSuccess = true
            };
        }
    }
}
