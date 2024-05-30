using Education.Application.Abstractions;
using Education.Application.UseCases.MessageCases.Queries;
using Education.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.MessageCases.Handlers.QueryHandlers
{
    public class GetMessageByIdQueryHandler : IRequestHandler<GetMessageByIdQuery, MessageModel>
    {
        private readonly IEducationDbContext _context;
        public GetMessageByIdQueryHandler(IEducationDbContext context)
        {
            _context = context;
        }
        public async Task<MessageModel> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Messages.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (res == null)
            {
                return null;
            }
            return res;
        }
    }
}