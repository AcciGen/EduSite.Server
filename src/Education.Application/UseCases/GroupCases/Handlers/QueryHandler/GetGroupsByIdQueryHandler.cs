using Education.Application.Abstractions;
using Education.Application.UseCases.GroupCases.Queries;
using Education.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Application.UseCases.GroupCases.Handlers.QueryHandler
{
    public class GetGroupsByIdQueryHandler : IRequestHandler<GetGroupsByIdQuery, GroupModel>
    {
        private readonly IEducationDbContext _context;
        public GetGroupsByIdQueryHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<GroupModel> Handle(GetGroupsByIdQuery request, CancellationToken cancellationToken)
        {
            // Retrieve group based on CourseId
            var group = await _context.Groups
                .FirstOrDefaultAsync(x => x.CourseId == request.CourseId, cancellationToken);

            if (group == null)
            {
                return null; // Return null if group is not found
            }

            // Map Group entity to GroupModel object
            var groupModel = new GroupModel
            {
                Id = group.Id,
                GroupName = group.GroupName,
                CourseId = group.CourseId,
                // You may need to map other properties here
            };

            return groupModel;
        }
    }
}
