using Education.Domain.Entities.DemoModels;
using Education.Domain.Entities.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CourseCases.Cammands
{
    public class UpdateCourseCommand:IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public double TotalTime { get; set; }
        public double Price { get; set; }
        public int SoldCount { get; set; }
        public string Language { get; set; }
        public Guid UserId { get; set; }
        public Guid CouponId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
