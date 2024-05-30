using Education.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Domain.Entities
{
    public class CourseFeedbackModel
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Message { get; set; }
        public string UserId { get; set; }
        public Guid CourseId { get; set; }
        public virtual CourseModel Course { get; set; }
        public virtual UserModel User { get; set; }
    }
}
