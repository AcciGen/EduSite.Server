using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Domain.Entities
{
    public class CouponModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CouponCode { get; set; }
        public int Discount { get; set; }
    }
}
