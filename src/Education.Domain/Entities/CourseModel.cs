using Education.Domain.Entities.Auth;
using Education.Domain.Entities.Enums;

namespace Education.Domain.Entities
{
    public class CourseModel
    {
        public Guid Id { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public double TotalTime { get; set; } = 0;
        public double Price { get; set; }
        public int SoldCount { get; set; } = 0;
        public string Language { get; set; }
        public CourseActivityModel Activity { get; set; } = CourseActivityModel.Blocked;
        public string TeacherName { get; set; }
        public Guid? CouponId { get; set; }
        public Guid CategoryId { get; set; }
        public virtual CouponModel Coupon { get; set; }
        public virtual CategoryModel Category { get; set; }
        public virtual ICollection<LessonModel> Lessons { get; set; }
        public virtual ICollection<CourseFeedbackModel> CourseFeedbacks { get; set; }

        public virtual GroupModel Group { get; set; }
    }
}
