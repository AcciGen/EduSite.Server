using Education.Application.Abstractions;
using Education.Application.UseCases.QuizCase.Commands;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.QuizCase.Handlers.CommandHandler
{
    public class CreateQuizHandler : IRequestHandler<CreateQuizCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;

        public CreateQuizHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = new QuizModel()
            {
                CourseId = request.CourseId,
                Id = Guid.NewGuid(),
                Title = request.Title,
            };

            await _context.Quizes.AddAsync(quiz);
            await _context.SaveChangesAsync();

            return new ResponseModel()
            {
                Message = "Quiz created successfully",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}
