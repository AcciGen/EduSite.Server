using Education.Application.Abstractions;
using Education.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Application.UseCases.VideoCases.Queries
{
    public class GetVideoByLessonIdQueryHandler : IRequestHandler<GetVideoByLessonIdQuery, VideoModel>
    {
        private readonly IEducationDbContext _context;

        public GetVideoByLessonIdQueryHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<VideoModel> Handle(GetVideoByLessonIdQuery request, CancellationToken cancellationToken)
        {
            var video = await _context.Videos
                .FirstOrDefaultAsync(v => v.LessonId == request.LessonId, cancellationToken);

            return video;
        }
    }
}
