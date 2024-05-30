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
    public class DeleteQuizHandler : IRequestHandler<DeleteQuizCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;

        public DeleteQuizHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = await _context.Quizes.FirstOrDefaultAsync(x => x.Id == request.Id);

            if(quiz == null)
            {
                return new ResponseModel()
                {
                    Message = "Quiz not found",
                    StatusCode = 404,
                    IsSuccess = true
                };
            }

            _context.Quizes.Remove(quiz);
            await _context.SaveChangesAsync();

            return new ResponseModel()
            {
                Message = "Quiz deleted",
                StatusCode = 200,
                IsSuccess = false
            };

        }
    }
}
