using Education.Application.Abstractions;
using Education.Application.UseCases.VideoFeedbackCases.Commands;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Application.UseCases.VideoFeedbackCases.Handlers.CommandHandler
{
    public class CreateVideoFeedbackCommandHandler : IRequestHandler<CreateVideoFeedbackCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;

        public CreateVideoFeedbackCommandHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateVideoFeedbackCommand request, CancellationToken cancellationToken)
        {
            var video = await _context.Videos.FirstOrDefaultAsync(x => x.Id == request.VideoModelId);
            if (video == null)
            {
                return new ResponseModel
                {
                    Message = "Video not found",
                    StatusCode = 404,
                    IsSuccess = false
                };
            }

            var feedback = new VideoFeedbackModel
            {
                Message = request.Message,
                UserId = request.UserId,
                VideoModellId = request.VideoModelId
            };

            // Add the new feedback to the video
            video.Feedbacks.Add(feedback);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Log the exception
                Console.WriteLine($"DbUpdateConcurrencyException occurred: {ex.Message}");

                // Handle concurrency conflict
                return new ResponseModel
                {
                    Message = "Concurrency conflict: The video data has been modified by another process. Please try again.",
                    StatusCode = 409, // Conflict
                    IsSuccess = false
                };
            }

            return new ResponseModel
            {
                Message = "Successfully created",
                StatusCode = 201,
                IsSuccess = true
            };
        }
    }
}
