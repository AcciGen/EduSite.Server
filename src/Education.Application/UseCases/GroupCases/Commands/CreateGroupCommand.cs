using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.GroupCases.Commands
{
    public class CreateGroupCommand:IRequest<ResponseModel>
    {
        public string GroupName { get; set; }
        public Guid CourseId { get; set; }
    }
}
