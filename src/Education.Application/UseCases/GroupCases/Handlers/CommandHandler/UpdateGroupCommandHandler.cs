using Education.Application.Abstractions;
using Education.Application.UseCases.GroupCases.Commands;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.GroupCases.Handlers.CommandHandler
{
    public class UpdateGroupCommandHandler:IRequestHandler<UpdateGroupCommand,ResponseModel>
    {
        private readonly IEducationDbContext _context;
        public UpdateGroupCommandHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Groups.FirstOrDefaultAsync(x => x.Id == request.Id);
            if(res == null)
            {
                return new ResponseModel()
                {
                    Message = "Group not found",
                    StatusCode = 404,
                    IsSuccess = false
                };
            }
            res.GroupName = request.GroupName;
            res.CourseId = request.CourseId;
            _context.Groups.Update(res);
            await _context.SaveChangesAsync();
            return new ResponseModel()
            {
                Message = "Seccesfully updated",
                StatusCode = 201,
                IsSuccess = true
            };
        }
    }
}
