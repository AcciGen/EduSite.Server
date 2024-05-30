using Education.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.VideoCases.Queries
{
    public class GetAllVideosByCourseIdQuery:IRequest<List<VideoModel>>
    {
        public Guid CourseId { get; set; }
    }
}
 