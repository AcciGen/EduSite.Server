using Education.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CouponCase.Queries
{
    public class GetAllCouponQuery : IRequest<List<CouponModel>>
    {

    }
}
