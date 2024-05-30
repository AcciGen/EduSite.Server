using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.UserActivityCase.Commands
{
    public class CreateUserActivityCommand : IRequest<ResponseModel>
    {
        public double WatchedVideosByMinute { get; set; }
        public Guid UserId { get; set; }
    }
}
