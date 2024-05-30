using Education.Application.Abstractions;
using Education.Application.UseCases.GroupCases.Commands;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.GroupCases.Handlers.CommandHandler
{
    public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;
        public DeleteGroupCommandHandler(IEducationDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Groups.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (res == null)
            {
                return new ResponseModel()
                {
                    Message = "Group not found",
                    StatusCode = 404,
                    IsSuccess = false
                };
            }
            _context.Groups.Remove(res);
            await _context.SaveChangesAsync();
            return new ResponseModel()
            {
                Message = "Sucsesfully deleted",
                StatusCode = 201,
                IsSuccess = true
            };
        }
    }
}
