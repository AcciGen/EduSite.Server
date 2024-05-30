using Education.Application.Abstractions;
using Education.Application.UseCases.QuizCase.Queries;
using Education.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.QuizCase.Handlers.QueryHandler
{
    public class GetByIdQuizQueryHandler : IRequestHandler<GetByIdQuizQuery, QuizModel>
    {
        private readonly IEducationDbContext _context;

        public GetByIdQuizQueryHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<QuizModel> Handle(GetByIdQuizQuery request, CancellationToken cancellationToken)
        {
            var quiz = await _context.Quizes.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (quiz != null)
            {
                return quiz;
            }

            return null!;
        }
    }
}
