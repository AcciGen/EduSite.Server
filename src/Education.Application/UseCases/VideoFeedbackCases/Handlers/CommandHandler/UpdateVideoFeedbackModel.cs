using Education.Application.Abstractions;
using Education.Application.UseCases.VideoCases.Command;
using Education.Application.UseCases.VideoFeedbackCases.Commands;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Application.UseCases.VideoFeedbackCases.Handlers.CommandHandler
{
    public class UpdateVideoFeedbackModel : IRequestHandler<UpdateVideoFeedbackCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateVideoFeedbackModel(IEducationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel> Handle(UpdateVideoFeedbackCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var res = await _context.VideoFeedbacks.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (res == null)
            {
                return new ResponseModel()
                {
                    Message = "Message not found",
                    StatusCode = 404,
                    IsSuccess = true
                };
            }

            if (res.UserId != userId)
            {
                return new ResponseModel()
                {
                    Message = "You don't have permission to update this video feedback",
                    StatusCode = 403,
                    IsSuccess = false
                };
            }

            res.Message = request.Message;

            await _context.SaveChangesAsync();

            return new ResponseModel()
            {
                Message = "Video feedback updated successfully",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}
