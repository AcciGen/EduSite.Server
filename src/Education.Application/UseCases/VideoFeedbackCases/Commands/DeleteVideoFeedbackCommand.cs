using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.VideoFeedbackCases.Commands
{
    public class DeleteVideoFeedbackCommand:IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
}