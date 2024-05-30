using Education.Application.Abstractions;
using Education.Application.UseCases.VideoCases.Command;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Application.UseCases.VideoCases.Handlers.CommandsHandlers
{
    public class UpdateVideoCommandHandler : IRequestHandler<UpdateVideoCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UpdateVideoCommandHandler(IEducationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(UpdateVideoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingVideo = _context.Videos.FirstOrDefault(v => v.LessonId == request.LessonId);

                if (existingVideo != null)
                {
                    string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, existingVideo.FolderName);
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(request.Video.FileName);
                    string filePath = Path.Combine(folderPath, fileName);

                    using (FileStream stream = File.OpenWrite(filePath))
                    {
                        await request.Video.CopyToAsync(stream);
                    }

                    existingVideo.VideoPath = filePath;
                    existingVideo.Length = request.Video.Length.ToString();

                    await _context.SaveChangesAsync(cancellationToken);

                    return new ResponseModel()
                    {
                        Message = "Video updated successfully",
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
                    Message = "Failed to update video: " + ex.Message,
                    StatusCode = 500,
                    IsSuccess = false
                };
            }
        }
    }
}
