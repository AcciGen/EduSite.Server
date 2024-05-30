using Education.Application.Abstractions;
using Education.Application.UseCases.CourseFeedbackCase.Commands;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CourseFeedbackCase.Handlers.CommandHandler
{
    public class DeleteCourseFeedbackHandler : IRequestHandler<DeleteCourseFeedbackCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;

        public DeleteCourseFeedbackHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteCourseFeedbackCommand request, CancellationToken cancellationToken)
        {
            var courseFeedback = await _context.CourseFeedbacks.FirstOrDefaultAsync(x => x.Id == request.FeedbackId);

            if(courseFeedback == null)
            {
                return new ResponseModel()
                {
                    Message = "Course feedback not found",
                    StatusCode = 404,
                    IsSuccess = true
                };
            }

            _context.CourseFeedbacks.Remove(courseFeedback);
            await _context.SaveChangesAsync();

            return new ResponseModel()
            {
                Message = "Course feedback deleted successfully",
                StatusCode = 200,
                IsSuccess = false
            };

        }
    }
}
