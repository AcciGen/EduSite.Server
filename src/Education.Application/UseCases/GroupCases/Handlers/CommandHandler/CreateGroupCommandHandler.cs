using Education.Application.Abstractions;
using Education.Application.UseCases.GroupCases.Commands;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Education.Application.UseCases.GroupCases.Handlers.CommandHandler
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;
        public CreateGroupCommandHandler(IEducationDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = new GroupModel()
            {
                GroupName = request.GroupName,
                CourseId = request.CourseId
            };
            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();
            return new ResponseModel()
            {
                Message = "Seccesfully created",
                StatusCode = 201,
                IsSuccess = true
            };
        }
    }
}
