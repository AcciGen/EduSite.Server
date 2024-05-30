using Education.Application.Abstractions;
using Education.Application.UseCases.LessonCase.Commands;
using Education.Domain.Entities.DemoModels;
using Education.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public class CreateLessonHandler : IRequestHandler<CreateLessonCommand, ResponseModel>
{
    private readonly IEducationDbContext _context;
    private readonly IMediator _mediator;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public CreateLessonHandler(IEducationDbContext context, IMediator mediator, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _mediator = mediator;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<ResponseModel> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
    {
        var course = await _context.Courses.FindAsync(request.CourseId);
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

        VideoModel videoModel = null;

        try
        {
            await SaveVideoFile(request.Video, folderPath, fileName);


            videoModel = new VideoModel()
            {
                VideoPath = videoPath,
                FolderName = course.CourseName,
                Length = request.Video.Length.ToString(),
                 
            };
            _context.Videos.Add(videoModel);
            await _context.SaveChangesAsync();

            var lesson = new LessonModel()
            {
                CourseId = request.CourseId,
                ExpForWatching = request.ExpForWatching,
                VideoModelId = videoModel.Id, 
                Title = request.Title
            };

            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync(); 
            videoModel.LessonId = lesson.Id;
            await _context.SaveChangesAsync();
            return new ResponseModel()
            {
                Message = "Lesson created successfully",
                StatusCode = 200,
                IsSuccess = true
            };
        }
        catch (Exception ex)
        {
            return new ResponseModel()
            {
                Message = "Failed to upload video: " + ex.Message,
                StatusCode = 500,
                IsSuccess = false
            };
        }
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
