using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.StatisticsCase.Queries
{
    public class GetAllStatisticsQuery : IRequest<List<StatisticModel>>
    {

    }
}
