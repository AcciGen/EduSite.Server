using Education.Application.Abstractions;
using Education.Application.UseCases.StatisticsCase.Commands;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.StatisticsCase.Handlers.CommandHandler
{
    public class CreateStatisticsHandler : IRequestHandler<CreateStatisticsCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;

        public CreateStatisticsHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateStatisticsCommand request, CancellationToken cancellationToken)
        {
            var statistics = new StatisticModel()
            {
                Id = Guid.NewGuid(),
                ActiveMembers = request.ActiveMembers,
                ActiveStudents = request.ActiveStudents,
                Countries = request.Countries,
            };

            await _context.Statistics.AddAsync(statistics);
            await _context.SaveChangesAsync();

            return new ResponseModel()
            {
                Message = "Statistics created",
                StatusCode = 200,
                IsSuccess = true
            };

        }
    }
}
