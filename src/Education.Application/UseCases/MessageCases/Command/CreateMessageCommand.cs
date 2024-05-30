using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.MessageCases.Command
{
    public class CreateMessageCommand:IRequest<ResponseModel>
    {
        public string Message { get; set; }
        public Guid GoupId { get; set; }
        public Guid SenderId { get; set; }
    }
}
