using Education.Application.Abstractions;
using Education.Application.UseCases.QuestionCase.Queries;
using Education.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.QuestionCase.Handlers.QueryHandler
{
    public class GetAllQuestionsQueryHAndler : IRequestHandler<GetAllQuestionsQuery, List<QuestionModel>>
    {
        private readonly IEducationDbContext _context;

        public GetAllQuestionsQueryHAndler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<List<QuestionModel>> Handle(GetAllQuestionsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Questions.ToListAsync();

            if(result.Count > 0 || result != null)
            {
                return result;
            }

            return null!;
        }
    }
}
