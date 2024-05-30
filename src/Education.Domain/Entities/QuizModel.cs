using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Domain.Entities
{
    public class QuizModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid CourseId { get; set; }
        public virtual CourseModel Course { get; set; }
        public virtual List<QuestionModel> Questions { get; set; }
    }
}
