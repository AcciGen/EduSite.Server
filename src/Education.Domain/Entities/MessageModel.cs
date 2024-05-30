using Education.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Domain.Entities
{
    public class MessageModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Message { get; set; }
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
        public Guid GroupId { get; set; }
        public string SenderId { get; set; }
        public virtual GroupModel Group { get; set; }
        public virtual UserModel Sender { get; set; }
    }
}
