using Education.Application.Abstractions;
using Education.Application.UseCases.VideoCases.Queries;
using Education.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Application.UseCases.VideoCases.Handlers.QueriesHandlers
{
    public class GetAllVideosByCourseIdQueryHandler : IRequestHandler<GetAllVideosByCourseIdQuery, List<VideoModel>>
    {
        private readonly IEducationDbContext _context;

        public GetAllVideosByCourseIdQueryHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<List<VideoModel>> Handle(GetAllVideosByCourseIdQuery request, CancellationToken cancellationToken)
        {
            // Retrieve all lesson IDs associated with the specified course ID
            var lessonIds = await _context.Lessons
                .Where(l => l.CourseId == request.CourseId)
                .Select(l => l.Id)
                .ToListAsync(cancellationToken);

            // Retrieve all videos where the lesson ID is in the list of lesson IDs
            var videos = await _context.Videos
                .Where(v => lessonIds.Contains(v.LessonId))
                .ToListAsync(cancellationToken);

            return videos;
        }
    }
}
