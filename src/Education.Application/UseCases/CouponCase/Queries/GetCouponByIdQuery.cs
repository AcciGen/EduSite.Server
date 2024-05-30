using Education.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CouponCase.Queries
{
    public class GetCouponByIdQuery : IRequest<CouponModel>
    {
        public Guid Id { get; set; }
    }
}
