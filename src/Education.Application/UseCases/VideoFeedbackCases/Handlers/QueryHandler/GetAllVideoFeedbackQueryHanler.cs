using Education.Application.Abstractions;
using Education.Application.UseCases.VideoFeedbackCases.Queries;
using Education.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.VideoFeedbackCases.Handlers.QueryHandler
{
    public class GetAllVideoFeedbackQueryHanler : IRequestHandler<GetAllVideoFeedbacksQuery, List<VideoFeedbackModel>>
    {
        private readonly IEducationDbContext _context;

        public GetAllVideoFeedbackQueryHanler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<List<VideoFeedbackModel>> Handle(GetAllVideoFeedbacksQuery request, CancellationToken cancellationToken)
        {
            var videoFeedbacks = _context.VideoFeedbacks
               .Where(vf => vf.VideoModellId == request.VideoId)
               .ToList();

            return videoFeedbacks;
        }
    }
}
