using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Domain.Entities
{
    public class StatisticModel
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public int ActiveStudents { get; set; }
        public int ActiveMembers { get; set; }
        public int Countries {  get; set; }
    }
}
