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
    public class DeleteQuestionHandler : IRequestHandler<DeleteQuestionCommand, ResponseModel>
    {

        private readonly IEducationDbContext _context;

        public DeleteQuestionHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await _context.Questions.FirstOrDefaultAsync(x => x.Id == request.Id);

            if(question != null)
            {
                return new ResponseModel()
                {
                    Message = "Question deleted",
                    StatusCode = 200,
                    IsSuccess = true
                };


            }

            _context.Questions.Remove(question!);
            await _context.SaveChangesAsync();

            return new ResponseModel()
            {
                Message = "Question not found",
                StatusCode = 200,
                IsSuccess = false
            };
        }
    }
}
