using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.LessonCase.Commands
{
    public class CreateLessonCommand : IRequest<ResponseModel>
    {
        public IFormFile Video { get; set; }
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public int ExpForWatching { get; set; }
    }
}
