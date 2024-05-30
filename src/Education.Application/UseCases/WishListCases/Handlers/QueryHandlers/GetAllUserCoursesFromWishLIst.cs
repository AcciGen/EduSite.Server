using Education.Application.Abstractions;
using Education.Application.UseCases.WishListCases.Queries;
using Education.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.WishListCases.Handlers.QueryHandlers
{
    public class GetAllUserCoursesFromWishLIst : IRequestHandler<GetAllCourseFromWishListQuery, List<CourseModel>>
    {
        private readonly IEducationDbContext _context;
        public GetAllUserCoursesFromWishLIst(IEducationDbContext context)
        {
            _context = context;
        }
        public async Task<List<CourseModel>> Handle(GetAllCourseFromWishListQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
            if(user  == null)
            {
                return null;
            }
            return user.WishList;
        }
    }
}
