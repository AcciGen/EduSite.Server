using Education.Application.Abstractions;
using Education.Application.UseCases.UserCases.Commands;
using Education.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.UserCases.Handlers.CommandHandler
{
    public class GetUserCoursesCommandHandler : IRequestHandler<GetUserCoursesCommand, List<CourseModel>>
    {
        private readonly IEducationDbContext _context;
        public GetUserCoursesCommandHandler(IEducationDbContext context)
        {
            _context = context;
        }
        public async Task<List<CourseModel>> Handle(GetUserCoursesCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id ==  request.UserId);
            if (user == null)
            {
                return null;
            }
            return user.Courses;
        }
    }
}
