using Education.Application.Abstractions;
using Education.Application.UseCases.StatisticsCase.Queries;
using Education.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.StatisticsCase.Handlers.QueryHandler
{
    public class GetAllStatisticsQueryHandler : IRequestHandler<GetAllStatisticsQuery, List<StatisticModel>>
    {

        private readonly IEducationDbContext _context;

        public GetAllStatisticsQueryHandler(IEducationDbContext context)
        {
            _context = context;
        }
        public async Task<List<StatisticModel>> Handle(GetAllStatisticsQuery request, CancellationToken cancellationToken)
        {
            
            var result = await _context.Statistics.ToListAsync();

            if(result == null)
            {
                return null!;
            }

            return result;

        }
    }
}
