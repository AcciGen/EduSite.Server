using Education.Application.Abstractions;
using Education.Application.UseCases.UserActivityCase.Commands;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.UserActivityCase.Handlers.CommandHandler
{
    public class DeleteUserActivityHandler : IRequestHandler<DeleteUserActivityCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;

        public DeleteUserActivityHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteUserActivityCommand request, CancellationToken cancellationToken)
        {
            var userActivity = await _context.UserActivityModels.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (userActivity == null)
            {
                return new ResponseModel()
                {
                    Message = "UserActivity not found",
                    StatusCode = 404,
                    IsSuccess = true
                };
            }

            _context.UserActivityModels.Remove(userActivity);
            await _context.SaveChangesAsync();

            return new ResponseModel()
            {
                Message = "UserActivity deleted successfully",
                StatusCode = 200,
                IsSuccess = false
            };
        }
    }
}
