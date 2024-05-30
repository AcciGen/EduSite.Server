using Education.Application.Abstractions;
using Education.Application.UseCases.CourseCases.Queries;
using Education.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CourseCases.Handlers.QueryHandlers
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, CourseModel>
    {
        private readonly IEducationDbContext _context;
        public GetCourseByIdQueryHandler(IEducationDbContext context)
        {
            _context = context;
        }
        public async Task<CourseModel> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Courses.FirstOrDefaultAsync(x => x.Id == request.Id);
            if(res == null)
            {
                return null;
            }
            return res;
        }
    }
}
