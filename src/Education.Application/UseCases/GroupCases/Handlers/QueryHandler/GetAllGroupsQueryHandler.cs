using Education.Application.Abstractions;
using Education.Application.UseCases.GroupCases.Queries;
using Education.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.GroupCases.Handlers.QueryHandler
{
    public class GetAllGroupsQueryHandler : IRequestHandler<GetAllGroupsQuery, List<GroupModel>>
    {
        private readonly IEducationDbContext _context;
        public GetAllGroupsQueryHandler(IEducationDbContext context)
        {
            _context = context;
        }
        public async Task<List<GroupModel>> Handle(GetAllGroupsQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Groups.ToListAsync(cancellationToken);
            return res; 
        }
    }
}
