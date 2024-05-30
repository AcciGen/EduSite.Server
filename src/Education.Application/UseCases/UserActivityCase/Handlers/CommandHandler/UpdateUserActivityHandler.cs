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
    public class UpdateUserActivityHandler : IRequestHandler<UpdateUserActivityCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;

        public UpdateUserActivityHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateUserActivityCommand request, CancellationToken cancellationToken)
        {
            var userActivity = await _context.UserActivityModels.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (userActivity == null)
            {
                return new ResponseModel()
                {
                    Message = "User Activity not found",
                    StatusCode = 404,
                    IsSuccess = true
                };
            }

            userActivity.Date = request.Date;
            userActivity.UserId = request.UserId.ToString();
            userActivity.WatchedVideosByMinute = request.WatchedVideosByMinute;

            _context.UserActivityModels.Update(userActivity);
            await _context.SaveChangesAsync();

            return new ResponseModel()
            {
                Message = "User Activity updated successfully",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}
