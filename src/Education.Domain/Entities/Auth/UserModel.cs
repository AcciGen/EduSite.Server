
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Domain.Entities.Auth
{
    public class UserModel : IdentityUser
    {
        public string FullName { get; set; }
        public int Exp { get; set; } = 0;
        public int Rank { get; set; } = 0;
        public int LearningTime { get; set; } = 0;
        public int CompletedCourses { get; set; } = 0;
        public string? PhotoPath { get; set; }
        public string Country { get; set; }
        public DateTimeOffset JoinedData { get; set; } = DateTimeOffset.UtcNow;
        public bool IsActive { get; set; } = true;
        [NotMapped]
        public virtual List<CourseModel> WishList { get; set; } = new List<CourseModel>();
        public Guid? GroupModelId { get; set; } 
        public string? Role { get; set; } = "User";
        public virtual List<CourseModel> Courses { get; set; }
        public virtual GroupModel GroupModel { get; set; }

    }
}
