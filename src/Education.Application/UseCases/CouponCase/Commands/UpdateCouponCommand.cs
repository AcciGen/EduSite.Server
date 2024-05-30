using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CouponCase.Commands
{
    public class UpdateCouponCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public string NewCouponCode { get; set; }
        public int NewDiscount { get; set; }

    }
}
