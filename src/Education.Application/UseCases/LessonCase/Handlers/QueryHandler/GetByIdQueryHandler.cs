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
    public class GetByIdQueryHandler : IRequestHandler<GetByIdLessonQuery, LessonModel>
    {
        private readonly IEducationDbContext _context;

        public GetByIdQueryHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<LessonModel> Handle(GetByIdLessonQuery request, CancellationToken cancellationToken)
        {
            var lesson = await _context.Lessons.FirstOrDefaultAsync(x =>  x.Id == request.Id);

            if(lesson == null)
            {
                return null!;
            }

            return lesson;
        }
    }
}
