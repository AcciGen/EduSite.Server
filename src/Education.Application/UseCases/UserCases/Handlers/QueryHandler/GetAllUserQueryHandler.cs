using Education.Application.Abstractions;
using Education.Application.UseCases.UserCases.Queries;
using Education.Domain.Entities.Auth;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.UserCases.Handlers.QueryHandler
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserModel>>
    {
        private readonly IEducationDbContext _context;
        public GetAllUserQueryHandler(IEducationDbContext context)
        {
            _context = context;
        }
        public async Task<List<UserModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.Users.OrderByDescending(x =>x.Exp).ToListAsync();
            return users;
        }
    }
}
