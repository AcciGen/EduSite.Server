using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.StatisticsCase.Commands
{
    public class UpdateStatisticsCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public int ActiveStudents { get; set; }
        public int ActiveMembers { get; set; }
        public int Countries { get; set; }
    }
}
