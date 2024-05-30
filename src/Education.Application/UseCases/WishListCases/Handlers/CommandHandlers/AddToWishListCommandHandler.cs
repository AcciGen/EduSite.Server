using Education.Application.Abstractions;
using Education.Application.UseCases.WishListCases.Commands;
using Education.Domain.Entities;
using Education.Domain.Entities.Auth; // Import UserModel
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Application.UseCases.WishListCases.Handlers.CommandHandlers
{
    public class AddToWishListCommandHandler : IRequestHandler<AddToWishListCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;

        public AddToWishListCommandHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(AddToWishListCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .Include(u => u.WishList) 
                .FirstOrDefaultAsync(u => u.Id == request.UserId);

            if (user == null)
            {
                return new ResponseModel
                {
                    Message = "User not found",
                    StatusCode = 404,
                    IsSuccess = false
                };
            }

            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == request.CourseId);

            if (course == null)
            {
                return new ResponseModel
                {
                    Message = "Course not found",
                    StatusCode = 404,
                    IsSuccess = false
                };
            }


            if (user.WishList.Any(c => c.Id == request.CourseId))
            {
                return new ResponseModel
                {
                    Message = "Course is already in the wish list",
                    StatusCode = 400,
                    IsSuccess = false
                };
            }

            user.WishList.Add(course);

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException)
            {
                return new ResponseModel
                {
                    Message = "Failed to add course to wish list",
                    StatusCode = 500,
                    IsSuccess = false
                };
            }

            return new ResponseModel
            {
                Message = "Course added to wish list successfully",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}
