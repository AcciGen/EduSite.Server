using Education.Application.Abstractions;
using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.VideoFeedbackCases.Commands
{
    public class CreateVideoFeedbackCommand:IRequest<ResponseModel>
    {
        public string Message { get; set; }
        public string UserId { get; set; }
        public Guid VideoModelId { get; set; }
    }
}
