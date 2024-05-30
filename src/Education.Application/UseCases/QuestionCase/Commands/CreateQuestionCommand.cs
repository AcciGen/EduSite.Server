using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.QuestionCase.Commands
{
    public class CreateQuestionCommand : IRequest<ResponseModel>
    {
        public string Question { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public char CorrectOption { get; set; }
        public int Exp { get; set; }
        public Guid QuizModelId { get; set; }
    }
}
