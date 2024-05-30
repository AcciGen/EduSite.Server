using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Domain.Entities
{
    public class LessonModel
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public int ExpForWatching { get; set; }
        //Pasdagi ma'lumotlargaCRUD amali bo'lmaydi
        public Guid? VideoModelId { get; set; } 
        public Guid CourseId { get; set; }
        public virtual CourseModel Course { get; set; }
        public virtual VideoModel VideoModel { get; set; }
    }
}
