using Education.Application.Abstractions;
using Education.Application.UseCases.UserActivityCase.Commands;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.UserActivityCase.Handlers.CommandHandler
{
    public class CreateUserActivityHandler : IRequestHandler<CreateUserActivityCommand, ResponseModel>
    {

        private readonly IEducationDbContext _context;

        public CreateUserActivityHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateUserActivityCommand request, CancellationToken cancellationToken)
        {
            var userActivity = new UserActivityModel()
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId.ToString(),
                WatchedVideosByMinute = request.WatchedVideosByMinute,
            };

            await _context.UserActivityModels.AddAsync(userActivity);
            await _context.SaveChangesAsync();

            return new ResponseModel()
            {
                Message = "UserActivity created successfully",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}
