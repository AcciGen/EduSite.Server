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
    public class UpdateStatisticsHandler : IRequestHandler<UpdateStatisticsCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;

        public UpdateStatisticsHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateStatisticsCommand request, CancellationToken cancellationToken)
        {
            var statistics = await _context.Statistics.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (statistics == null)
            {
                return new ResponseModel { Message = "Statistics not found", StatusCode = 404, IsSuccess  = false };
            }

            statistics.ActiveMembers = request.ActiveMembers;
            statistics.ActiveStudents = request.ActiveStudents;
            statistics.Countries = request.Countries;

            _context.Statistics.Update(statistics);
            await _context.SaveChangesAsync();

            return new ResponseModel { Message = "Statistics updated", StatusCode = 200, IsSuccess = true};


            
        }
    }
}
