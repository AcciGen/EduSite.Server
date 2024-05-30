using Education.Application.Abstractions;
using Education.Application.UseCases.MessageCases.Command;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.MessageCases.Handlers.CommandHandlers
{
    public class DeleteMessageCommandHandler : IRequestHandler<DeleteMessageCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;
        public DeleteMessageCommandHandler(IEducationDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Messages.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (res == null)
            {
                return new ResponseModel()
                {
                    Message = "Message not found",
                    StatusCode = 404,
                    IsSuccess = false
                };
            }
            _context.Messages.Remove(res);
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseModel()
            {
                Message = "Succesfully deleted",
                StatusCode = 201,
                IsSuccess = true
            };

        }
    }
}
