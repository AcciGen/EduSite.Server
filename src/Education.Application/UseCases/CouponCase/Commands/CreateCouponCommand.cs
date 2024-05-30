using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CouponCase.Commands
{
    public class CreateCouponCommand : IRequest<ResponseModel>
    {
        public string CouponCode { get; set; }
        public int Discount { get; set; }
    }
}
