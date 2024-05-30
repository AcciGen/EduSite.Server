using Education.Application.Abstractions;
using Education.Application.UseCases.LessonCase.Queries;
using Education.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.LessonCase.Handlers.QueryHandler
{
    public class GetAllLessonQueryHandler : IRequestHandler<GetAllLessonsQuery, List<LessonModel>>
    {
        private readonly IEducationDbContext _context;

        public GetAllLessonQueryHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<List<LessonModel>> Handle(GetAllLessonsQuery request, CancellationToken cancellationToken)
        {
            var lessons = await _context.Lessons.Where(x => x.CourseId == request.CourseId).ToListAsync();

            if(lessons == null)
            {
                return null!;
            }

            return lessons;
        }
    }
}
