using Education.Application.Abstractions;
using Education.Application.UseCases.QuestionCase.Commands;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.QuestionCase.Handlers.CommandHandler
{
    public class UpdateQuestionHandler : IRequestHandler<UpdateQuestionCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;

        public UpdateQuestionHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await _context.Questions.FirstOrDefaultAsync(x => x.Id == request.Id);

            if(question == null) 
            {
                return new ResponseModel()
                {
                    Message = "Question not found",
                    StatusCode = 404,
                    IsSuccess = true
                };
            }

            question.CorrectOption = request.CorrectOption;
            question.Exp = request.Exp;
            question.OptionA = request.OptionA;
            question.OptionB = request.OptionB;
            question.OptionC = request.OptionC;
            question.QuizModelId = request.QuizModelId;


            _context.Questions.Update(question);
            await _context.SaveChangesAsync();

            return new ResponseModel()
            {
                Message = "Question updated",
                StatusCode = 200,
                IsSuccess = true
            };


        }
    }
}
