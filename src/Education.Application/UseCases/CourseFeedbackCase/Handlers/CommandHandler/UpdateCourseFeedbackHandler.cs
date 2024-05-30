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
    public class UpdateCourseFeedbackHandler : IRequestHandler<UpdateCourseFeedbackCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;

        public UpdateCourseFeedbackHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateCourseFeedbackCommand request, CancellationToken cancellationToken)
        {
            var courseFeedback = await _context.CourseFeedbacks.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (courseFeedback == null)
            {
                return new ResponseModel { Message = "CourseFeedback not found", StatusCode = 404, IsSuccess = false };
            }

            courseFeedback.Message = request.Message;

            _context.CourseFeedbacks.Update(courseFeedback);

            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel { Message = "CourseFeedback updated successfully", StatusCode = 200, IsSuccess = true };

        }
    }
}
