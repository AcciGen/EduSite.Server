using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.UserActivityCase.Commands
{
    public class UpdateUserActivityCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public double WatchedVideosByMinute { get; set; }
        public Guid UserId { get; set; }
    }
}
