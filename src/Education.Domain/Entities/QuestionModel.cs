using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Domain.Entities
{
    public class QuestionModel
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public char CorrectOption { get; set; }
        public int Exp { get; set; }

        public Guid QuizModelId { get; set; }

        public virtual QuizModel QuizModel { get; set; }
    }
} 
