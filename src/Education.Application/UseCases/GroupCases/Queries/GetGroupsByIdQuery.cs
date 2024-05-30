using Education.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.GroupCases.Queries
{
    public class GetGroupsByIdQuery : IRequest<GroupModel>
    {
        public Guid CourseId { get; set; }
    }
}
