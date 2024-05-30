using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Domain.DTOS
{
    public class TokenDTO
    {
        public string Token { get; set; }
        public string Message {  get; set; }
        public bool IsSucceed { get; set; }
    }
}
