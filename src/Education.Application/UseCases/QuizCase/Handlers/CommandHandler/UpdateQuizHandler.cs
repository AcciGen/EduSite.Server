using Education.Application.Abstractions;
using Education.Application.UseCases.QuizCase.Commands;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.QuizCase.Handlers.CommandHandler
{
    public class UpdateQuizHandler : IRequestHandler<UpdateQuizCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;

        public UpdateQuizHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = await _context.Quizes.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (quiz == null)
            {
                return new ResponseModel()
                {
                    Message = "Quiz not found",
                    StatusCode = 404,
                    IsSuccess = true
                };
            }

            quiz.CourseId = request.CourseId;
            quiz.Title = request.Title;
            
            _context.Quizes.Update(quiz);
            await _context.SaveChangesAsync();

            return new ResponseModel()
            {
                Message = "Quiz updated",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}
