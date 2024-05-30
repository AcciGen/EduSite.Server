using Education.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.VideoCases.Queries
{
    public class GetVideoByLessonIdQuery : IRequest<VideoModel>
    {
        public Guid LessonId { get; set; }
    }
}
