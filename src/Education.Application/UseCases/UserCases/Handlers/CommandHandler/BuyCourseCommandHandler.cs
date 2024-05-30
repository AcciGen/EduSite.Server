using Education.Application.Abstractions;
using Education.Application.UseCases.UserCases.Commands;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class BuyCourseCommandHandler : IRequestHandler<BuyCourseCommand, ResponseModel>
{
    private readonly IEducationDbContext _context;

    public BuyCourseCommandHandler(IEducationDbContext context)
    {
        _context = context;
    }

    public async Task<ResponseModel> Handle(BuyCourseCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _context.Users
                .Include(u => u.Courses) 
                .FirstOrDefaultAsync(u => u.Id == request.UserId.ToString());

            if (user == null)
            {
                return new ResponseModel()
                {
                    Message = "User not found",
                    StatusCode = 404,
                    IsSuccess = false
                };
            }

            if (user.Courses.Any(c => c.Id == request.CourseId))
            {
                return new ResponseModel()
                {
                    Message = "User already has the course",
                    StatusCode = 400,
                    IsSuccess = false
                };
            }

            var course = await _context.Courses
                .Include(c => c.Group) 
                .FirstOrDefaultAsync(c => c.Id == request.CourseId);

            if (course == null)
            {
                return new ResponseModel()
                {
                    Message = "Course not found",
                    StatusCode = 404,
                    IsSuccess = false
                };
            }

            user.Courses.Add(course);

            course.Group.Students.Add(user);

            _context.Users.Update(user);
            _context.Groups.Update(course.Group);
            await _context.SaveChangesAsync();

            return new ResponseModel()
            {
                Message = "Course added to user's course list and user added to the course group",
                StatusCode = 200,
                IsSuccess = true
            };
        }
        catch (Exception ex)
        {
            return new ResponseModel()
            {
                Message = "Failed to add course to user's course list: " + ex.Message,
                StatusCode = 500,
                IsSuccess = false
            };
        }
    }
}
