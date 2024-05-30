using Education.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.QuestionCase.Queries
{
    public class GetAllQuestionsQuery : IRequest<List<QuestionModel>>
    {
    }
}
