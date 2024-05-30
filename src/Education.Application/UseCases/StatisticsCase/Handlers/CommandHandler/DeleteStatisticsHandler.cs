using Education.Application.Abstractions;
using Education.Application.UseCases.StatisticsCase.Commands;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.StatisticsCase.Handlers.CommandHandler
{
    public class DeleteStatisticsHandler : IRequestHandler<DeleteStatisticsCommand, ResponseModel>
    {

        private readonly IEducationDbContext _context;

        public DeleteStatisticsHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteStatisticsCommand request, CancellationToken cancellationToken)
        {
            var statistics = await _context.Statistics.FirstOrDefaultAsync(x => x.Id == request.Id);
            
            if (statistics == null)
            {
                return new ResponseModel()
                {
                    Message = "Statistics not found",
                    StatusCode = 404,
                    IsSuccess = true,
                };

            }

            _context.Statistics.Remove(statistics);
            await _context.SaveChangesAsync();

            return new ResponseModel()
            {
                Message = "Statistics deleted",
                StatusCode = 200,
                IsSuccess = true,
            };
        }
    }
}
