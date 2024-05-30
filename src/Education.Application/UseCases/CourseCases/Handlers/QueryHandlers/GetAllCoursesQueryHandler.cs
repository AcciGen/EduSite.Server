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
    public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCourseQuery, List<CourseModel>>
    {
        private readonly IEducationDbContext _context;
        public GetAllCoursesQueryHandler(IEducationDbContext context)
        {
            _context = context;
        }
        public async Task<List<CourseModel>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Courses.ToListAsync(cancellationToken);
            return res;
        }
    }
}
