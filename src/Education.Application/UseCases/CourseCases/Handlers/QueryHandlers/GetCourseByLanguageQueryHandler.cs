using Education.Application.Abstractions;
using Education.Application.UseCases.CourseCases.Queries;
using Education.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CourseCases.Handlers.QueryHandlers
{
    public class GetCourseByLanguageQueryHandler : IRequestHandler<GetCourseByLanguageQuery, List<CourseModel>>
    {
        private readonly IEducationDbContext _context;
        public async Task<List<CourseModel>> Handle(GetCourseByLanguageQuery request, CancellationToken cancellationToken)
        {
            var courses = await _context.Courses.Where(x => x.Language == request.Language).ToListAsync();

            if (courses == null || !courses.Any())
            {
                return null;
            }

            return courses;
        }

    }
}
