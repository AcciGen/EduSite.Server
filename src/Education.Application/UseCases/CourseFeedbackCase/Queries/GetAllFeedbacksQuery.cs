using Education.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CourseFeedbackCase.Queries
{
    public class GetAllFeedbacksQuery : IRequest<List<CourseFeedbackModel>>
    {
        public Guid CourseId { get; set; }
    }
}
