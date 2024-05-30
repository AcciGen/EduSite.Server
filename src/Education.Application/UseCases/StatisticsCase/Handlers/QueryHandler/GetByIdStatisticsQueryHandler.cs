using Education.Application.Abstractions;
using Education.Application.UseCases.StatisticsCase.Queries;
using Education.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.StatisticsCase.Handlers.QueryHandler
{
    public class GetByIdStatisticsQueryHandler : IRequestHandler<GetByIdStatisticsQuery, StatisticModel>
    {
        private readonly IEducationDbContext _context;

        public GetByIdStatisticsQueryHandler(IEducationDbContext context)
        {
            _context = context;
        }
        public async Task<StatisticModel> Handle(GetByIdStatisticsQuery request, CancellationToken cancellationToken)
        {
            
            var result = await _context.Statistics.FirstOrDefaultAsync(x => x.Id == request.Id);

            if(result == null)
            {
                return null!;
            }

            return result;


        }
    }
}
