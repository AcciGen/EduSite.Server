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
    public class GetByIdQuestionQueryHandler : IRequestHandler<GetQuestionByIdQuery, QuestionModel>
    {
        private readonly IEducationDbContext _context;

        public GetByIdQuestionQueryHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<QuestionModel> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
        {
            var question = await _context.Questions.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (question == null)
            {
                return null!;
            }

            return question;
        }
    }
}
