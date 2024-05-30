using Education.Application.Abstractions;
using Education.Application.UseCases.CourseFeedbackCase.Commands;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CourseFeedbackCase.Handlers.CommandHandler
{
    public class CreateCourseFeedbackHandler : IRequestHandler<CreateCourseFeedbackCommand, ResponseModel>
    {

        private readonly IEducationDbContext _context;

        public CreateCourseFeedbackHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateCourseFeedbackCommand request, CancellationToken cancellationToken)
        {
            var feedback = new CourseFeedbackModel()
            {
                Id = Guid.NewGuid(),
                Message = request.Message,
                CourseId = request.CourseId,
                UserId = request.UserId.ToString(),
            };

            await _context.CourseFeedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();

            return new ResponseModel() { StatusCode = 200, Message = "Feedback created successfully", IsSuccess = true };
        }
    }
}
