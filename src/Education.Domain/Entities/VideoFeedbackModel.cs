using Education.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Domain.Entities
{
    public class VideoFeedbackModel
    {
        public Guid Id { get; set; } // =  Guid.New() Bu hato ekan balla
        public string Message { get; set; }
        public string UserId {  get; set; }
        public Guid VideoModellId { get; set; }
        public virtual UserModel User { get; set; }
        public virtual VideoModel VideoModell { get; set; }
    }
}
