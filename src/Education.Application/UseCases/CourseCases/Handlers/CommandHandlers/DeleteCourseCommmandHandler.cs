using Education.Application.Abstractions;
using Education.Application.UseCases.CourseCases.Cammands;
using Education.Application.UseCases.CourseCases.Handlers.QueryHandlers;
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
    public class DeleteCourseCommmandHandler : IRequestHandler<DeleteCourseCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;
        public DeleteCourseCommmandHandler(IEducationDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Courses.FirstOrDefaultAsync(x => x.Id == request.Id);
            if(res == null)
            {
                return new ResponseModel()
                {
                    Message = "Course Not Found",
                    StatusCode = 404,
                    IsSuccess = false
                };
            }
            _context.Courses.Remove(res);
            await _context.SaveChangesAsync();
            return new ResponseModel()
            {
                Message = "Succesfully deleted",
                StatusCode = 201,
                IsSuccess = true
            };

        }
    }
}

