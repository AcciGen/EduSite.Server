using Education.Application.Abstractions;
using Education.Application.UseCases.LessonCase.Commands;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Application.UseCases.LessonCase.Handlers.CommandHandler
{
    public class UpdateLessonHandler : IRequestHandler<UpdateLessonCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UpdateLessonHandler(IEducationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
        {
            var lesson = await _context.Lessons.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (lesson == null)
            {
                return new ResponseModel()
                {
                    Message = "Lesson not found",
                    StatusCode = 404,
                    IsSuccess = false
                };
            }

            lesson.ExpForWatching = request.ExpForWatching;
            lesson.Title = request.Title;

            // Update lesson
            _context.Lessons.Update(lesson);
            await _context.SaveChangesAsync();

            if (request.NewVideo != null)
            {
                var courseId = lesson.CourseId;

                var course = await _context.Courses.FindAsync(courseId);
                if (course == null)
                {
                    return new ResponseModel()
                    {
                        Message = "Course not found",
                        StatusCode = 404,
                        IsSuccess = false
                    };
                }

                var folderPath = $"lessons/{course.CourseName}/";
                var fileName = $"{course.CourseName}_{DateTime.Now.ToString("yyyyMMddHHmmss")}.mp4";
                var videoPath = $"{folderPath}{fileName}";

                try
                {
                    await SaveVideoFile(request.NewVideo, folderPath, fileName);

                    var newVideoModel = new VideoModel()
                    {
                        VideoPath = videoPath,
                        FolderName = course.CourseName,
                        Length = request.NewVideo.Length.ToString(),
                        LessonId = lesson.Id 
                    };

                    _context.Videos.Add(newVideoModel);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return new ResponseModel()
                    {
                        Message = "Failed to upload new video: " + ex.Message,
                        StatusCode = 500,
                        IsSuccess = false
                    };
                }
            }

            return new ResponseModel()
            {
                Message = "Lesson updated",
                StatusCode = 200,
                IsSuccess = true
            };
        }

        private async Task SaveVideoFile(IFormFile video, string folderPath, string fileName)
        {
            var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            fullPath = Path.Combine(fullPath, fileName);

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await video.CopyToAsync(fileStream);
            }
        }
    }
}
