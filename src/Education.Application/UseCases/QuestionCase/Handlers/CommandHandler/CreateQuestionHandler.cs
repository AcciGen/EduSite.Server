using Education.Application.Abstractions;
using Education.Application.UseCases.QuestionCase.Commands;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Application.UseCases.QuestionCase.Handlers.CommandHandler
{
    public class CreateQuestionHandler : IRequestHandler<CreateQuestionCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;

        public CreateQuestionHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = new QuestionModel()
            {
                Question = request.Question,
                QuizModelId = request.QuizModelId,
                Exp = request.Exp,
                Id = Guid.NewGuid(),
                OptionA = request.OptionA,
                OptionB = request.OptionB,
                OptionC = request.OptionC,
                CorrectOption = request.CorrectOption,
            };

            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();

            return new ResponseModel()
            {
                Message = "Question created successfully",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}
