using Education.Application.Abstractions;
using Education.Application.UseCases.CategoryCases.Queries;
using Education.Application.UseCases.CouponCase.Queries;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CouponCase.Handlers.QueryHandler
{
    public class GetCouponByIdQueryHandler : IRequestHandler<GetCouponByIdQuery, CouponModel>
    {

        private readonly IEducationDbContext _context;

        public GetCouponByIdQueryHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<CouponModel> Handle(GetCouponByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Coupons.FirstOrDefaultAsync(x => x.Id == request.Id);
            
            if (result == null)
            {
                return null!;
            }

            return result!;

        
        }
    }
}
