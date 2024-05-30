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
    public class GetAllQuizQueryHandler : IRequestHandler<GetAllQuizQuery, List<QuizModel>>
    {
        private readonly IEducationDbContext _context;

        public GetAllQuizQueryHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<List<QuizModel>> Handle(GetAllQuizQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Quizes.ToListAsync();

            if (result.Count == 0 || result == null)
            {
                return null!;

            }

            return result;
        }
    }
}
