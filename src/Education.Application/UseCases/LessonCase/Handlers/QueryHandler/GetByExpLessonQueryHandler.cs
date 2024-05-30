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
    public class GetByExpLessonQueryHandler : IRequestHandler<GetByExpLessonQuery, List<LessonModel>>
    {
        private readonly IEducationDbContext _context;

        public GetByExpLessonQueryHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<List<LessonModel>> Handle(GetByExpLessonQuery request, CancellationToken cancellationToken)
        {
            var lessons = await _context.Lessons.Where(x => x.ExpForWatching == request.ExpForWatching).ToListAsync();

            if(lessons == null || lessons.Count == 0)
            {
                return null!;
            }

            return lessons;

        }
    }
}
