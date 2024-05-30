using Education.Application.Abstractions;
using Education.Application.UseCases.CourseCases.Cammands;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CourseCases.Handlers.CommandHandlers
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;
        public UpdateCourseCommandHandler(IEducationDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (course == null)
            {
                return new ResponseModel()
                {
                    Message = "Course not found",
                    StatusCode = 404,
                    IsSuccess = false
                };
            }
            _context.Courses.Update(course);
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseModel()
            {
                Message = "Succesfully updated",
                StatusCode = 201,
                IsSuccess = true
            };
        }
    }
}
