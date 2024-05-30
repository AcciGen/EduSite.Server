using Education.Application.Abstractions;
using Education.Application.UseCases.UserCases.Commands;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.UserCases.Handlers.CommandHandler
{
    public class AddExpCommandHandler : IRequestHandler<AddExpCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;

        public AddExpCommandHandler(IEducationDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(AddExpCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync( x => x.Id == request.UserId);
            if (user == null)
            {
                return new ResponseModel()
                {
                    Message = "User not found",
                    StatusCode = 404,
                    IsSuccess = true
                };
            }
            user.Exp += request.Exp;
            await _context.SaveChangesAsync();
            return new ResponseModel()
            {
                Message = "Added",
                StatusCode = 201,
                IsSuccess = true
            };
        }
    }
}
