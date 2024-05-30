using Education.Application.Abstractions;
using Education.Application.UseCases.CouponCase.Commands;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CouponCase.Handlers.CommandHandler
{
    public class CreateCouponHandler : IRequestHandler<CreateCouponCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;

        public CreateCouponHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateCouponCommand request, CancellationToken cancellationToken)
        {
            var coupon = new CouponModel()
            {
                CouponCode = request.CouponCode,
                Discount = request.Discount
            };

            await _context.Coupons.AddAsync(coupon);
            await _context.SaveChangesAsync();

            return new ResponseModel()
            {
                Message = "Coupon created successfully",
                StatusCode = 201,
                IsSuccess = true
            };
        }
    }
}
