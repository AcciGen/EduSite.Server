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
    public class UpdateMessageCommandHandler : IRequestHandler<UpdateMessageCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;
        public UpdateMessageCommandHandler(IEducationDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Messages.FirstOrDefaultAsync(x => x.Id == request.Id);
            if(res == null)
            {
                return new ResponseModel()
                {
                    Message = "Message not found",
                    StatusCode = 404,
                    IsSuccess = false,
                };
            }
            _context.Messages.Update(res);
            await _context.SaveChangesAsync();
            return new ResponseModel()
            {
                Message = "Seccesfully updated",
                StatusCode = 201,
                IsSuccess = true,
            };
        }
    }
}
