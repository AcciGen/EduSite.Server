using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Domain.Entities.DemoModels
{
    public class UserWishList
    {
        public string UserId { get; set; }
        public Guid CourseId { get; set; }
    }
}
