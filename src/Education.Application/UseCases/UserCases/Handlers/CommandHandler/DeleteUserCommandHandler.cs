using Education.Application.Abstractions;
using Education.Application.UseCases.UserCases.Commands;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Application.UseCases.UserCases.Handlers.CommandHandler
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DeleteUserCommandHandler(IEducationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == request.Id.ToString());
            if (user == null)
            {
                return new ResponseModel
                {
                    Message = "User not found",
                    StatusCode = 404,
                    IsSuccess = false
                };
            }

            if (!string.IsNullOrEmpty(user.PhotoPath))
            {
                var photoPath = Path.Combine(_webHostEnvironment.WebRootPath, user.PhotoPath.TrimStart('/'));
                if (File.Exists(photoPath))
                {
                    File.Delete(photoPath);
                }
            }

            user.IsActive = false;

            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel
            {
                Message = "User deleted successfully",
                StatusCode = 201,
                IsSuccess = true
            };
        }
    }
}
