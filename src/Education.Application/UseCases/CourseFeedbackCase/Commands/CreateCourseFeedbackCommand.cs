using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CourseFeedbackCase.Commands
{
    public class CreateCourseFeedbackCommand : IRequest<ResponseModel>
    {
        public string Message { get; set; }
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }
    }
}
