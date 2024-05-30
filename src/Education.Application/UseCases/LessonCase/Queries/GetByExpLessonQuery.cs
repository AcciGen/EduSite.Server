using Education.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.LessonCase.Queries
{
    public class GetByExpLessonQuery : IRequest<List<LessonModel>>
    {
        public int ExpForWatching { get; set; }
    }
}
