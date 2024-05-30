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
    public class GetByTitleLessonQueryHandler : IRequestHandler<GetByTitleLessonQuery, LessonModel>
    {
        private readonly IEducationDbContext _context;

        public GetByTitleLessonQueryHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<LessonModel> Handle(GetByTitleLessonQuery request, CancellationToken cancellationToken)
        {
            var lesson = await _context.Lessons.FirstOrDefaultAsync(x => x.Title == request.Title);

            if (lesson == null)
            {
                return null!;
            }

            return lesson;
        }
    }
}
