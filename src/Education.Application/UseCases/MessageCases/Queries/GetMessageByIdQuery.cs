using Education.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.MessageCases.Queries
{
    public class GetMessageByIdQuery:IRequest<MessageModel>
    {
        public Guid Id { get; set; }
    }
}
