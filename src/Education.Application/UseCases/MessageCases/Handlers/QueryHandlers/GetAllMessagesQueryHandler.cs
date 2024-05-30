using Education.Application.Abstractions;
using Education.Application.UseCases.CategoryCases.Queries;
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
    public class GetAllMessagesQueryHandler : IRequestHandler<GetAllMessagesQuery, List<MessageModel>>
    {
        private readonly IEducationDbContext _context;
        public GetAllMessagesQueryHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MessageModel>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Messages.ToListAsync();
            return res;
        }
    }
}
