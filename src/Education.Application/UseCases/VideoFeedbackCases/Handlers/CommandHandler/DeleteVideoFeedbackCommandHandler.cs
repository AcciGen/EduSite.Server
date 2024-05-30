using Education.Application.Abstractions;
using Education.Application.UseCases.VideoCases.Command;
using Education.Application.UseCases.VideoFeedbackCases.Commands;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.VideoFeedbackCases.Handlers.CommandHandler
{
    public class DeleteVideoFeedbackCommandHandler : IRequestHandler<DeleteVideoFeedbackCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;
        public DeleteVideoFeedbackCommandHandler(IEducationDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(DeleteVideoFeedbackCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.VideoFeedbacks.FirstOrDefaultAsync(x => x.Id == request.Id);
            if(res == null)
            {
                return new ResponseModel()
                {
                    Message = "Message not found",
                    StatusCode = 404,
                    IsSuccess = false,
                };
            }
             _context.VideoFeedbacks.Remove(res);
            await _context.SaveChangesAsync();
            return new ResponseModel()
            {
                Message = "Deleted",
                StatusCode = 201,
                IsSuccess = true,
            };
        }
    }
}
