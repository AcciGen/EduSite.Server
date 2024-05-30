using Education.Application.Abstractions;
using Education.Application.UseCases.UserCases.Commands;
using Education.Domain.Entities.Auth;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Application.UseCases.UserCases.Handlers.CommandHandler
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UpdateUserCommandHandler(IEducationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            // Parse the request Id to Guid
            if (!Guid.TryParse(request.Id.ToString(), out var userId))
            {
                return new ResponseModel
                {
                    Message = "Invalid user Id format",
                    StatusCode = 400, // Bad Request
                    IsSuccess = false
                };
            }

            var user = _context.Users.FirstOrDefault(x => x.Id == userId.ToString());
            if (user == null)
            {
                return new ResponseModel
                {
                    Message = "User not found",
                    StatusCode = 404,
                    IsSuccess = false
                };
            }

            // Update user properties
            user.FullName = request.FullName;
            user.Country = request.Counry; 
            user.Role = request.Role;

            if (request.Role != null)
            {
                user.Role = request.Role;
            }

            if (request.Photo != null)
            {
                if (!string.IsNullOrEmpty(user.PhotoPath))
                {
                    var existingPhotoPath = Path.Combine(_webHostEnvironment.WebRootPath, user.PhotoPath.TrimStart('/'));
                    if (File.Exists(existingPhotoPath))
                    {
                        File.Delete(existingPhotoPath);
                    }
                }

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(request.Photo.FileName);
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "UserPhotos", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.Photo.CopyToAsync(stream);
                }

                user.PhotoPath = "/UserPhotos/" + fileName;
            }
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel
            {
                Message = "User updated successfully",
                StatusCode = 201,
                IsSuccess = true
            };
        }
    }
}
