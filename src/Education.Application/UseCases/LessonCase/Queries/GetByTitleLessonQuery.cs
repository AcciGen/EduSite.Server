using Education.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Education.Application.UseCases.LessonCase.Queries
{
    public class GetByTitleLessonQuery : IRequest<LessonModel>
    {
        public string Title { get; set; }
    }
}
