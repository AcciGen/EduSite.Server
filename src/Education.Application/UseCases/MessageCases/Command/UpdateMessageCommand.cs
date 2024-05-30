using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.MessageCases.Command
{
    public class UpdateMessageCommand:IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTimeOffset Date { get; set; }
        public Guid GoupId { get; set; }
        public Guid SenderId { get; set; }
    }
}
