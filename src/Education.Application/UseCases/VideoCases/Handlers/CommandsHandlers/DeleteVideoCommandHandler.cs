using Education.Application.Abstractions;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Application.UseCases.VideoCases.Command
{
    public class DeleteVideoCommandHandler : IRequestHandler<DeleteVideoCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DeleteVideoCommandHandler(IEducationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(DeleteVideoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var videoToDelete = _context.Videos.FirstOrDefault(v => v.LessonId == request.LessonId);

                if (videoToDelete != null)
                {
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, videoToDelete.VideoPath);
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }

                  var res = _context.Videos.Remove(videoToDelete);
                    await _context.SaveChangesAsync(cancellationToken);

                    return new ResponseModel()
                    {
                        Message = "Video deleted successfully",
                        StatusCode = 200,
                        IsSuccess = true
                    };
                }
                else
                {
                    return new ResponseModel()
                    {
                        Message = "Video with the provided LessonId not found",
                        StatusCode = 404,
                        IsSuccess = false
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    Message = "Failed to delete video: " + ex.Message,
                    StatusCode = 500,
                    IsSuccess = false
                };
            }
        }
    }
}
