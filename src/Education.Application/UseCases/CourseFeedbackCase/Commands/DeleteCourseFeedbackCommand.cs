using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CourseFeedbackCase.Commands
{
    public class DeleteCourseFeedbackCommand : IRequest<ResponseModel>
    {
        public Guid FeedbackId { get; set; }
    }
}
