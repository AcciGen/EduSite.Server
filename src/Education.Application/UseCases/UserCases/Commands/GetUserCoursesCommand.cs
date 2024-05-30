using Education.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.UserCases.Commands
{
    public class GetUserCoursesCommand : IRequest<List<CourseModel>>
    {
        public string UserId { get; set; }
    }
}
