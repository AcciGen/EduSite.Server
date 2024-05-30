using Education.Application.Abstractions;
using Education.Application.UseCases.CourseFeedbackCase.Queries;
using Education.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CourseFeedbackCase.Handlers.QueryHandler
{
    public class GetAllFeedbacksQueryHandler : IRequestHandler<GetAllFeedbacksQuery, List<CourseFeedbackModel>>
    {
        private readonly IEducationDbContext _context;
        public GetAllFeedbacksQueryHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CourseFeedbackModel>> Handle(GetAllFeedbacksQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.CourseFeedbacks
               .Where(feedback => feedback.CourseId == request.CourseId)
               .ToListAsync(cancellationToken);

            return result;


        }
    }
}
