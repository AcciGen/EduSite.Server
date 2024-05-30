using Education.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Domain.Entities
{
    public class GroupModel
    {
        public Guid Id { get; set; }
        public string GroupName { get; set; }
        public Guid CourseId { get; set; }
        //Pasdagi ma'lumotlargaCRUD amali bo'lmaydi
        public virtual List<UserModel> Students { get; set; }
        public virtual List<MessageModel> Messages { get; set; }
        public virtual CourseModel Course { get; set; }
    }
}
