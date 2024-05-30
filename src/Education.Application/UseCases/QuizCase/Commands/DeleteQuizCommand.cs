using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.QuizCase.Commands
{
    public class DeleteQuizCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
}
