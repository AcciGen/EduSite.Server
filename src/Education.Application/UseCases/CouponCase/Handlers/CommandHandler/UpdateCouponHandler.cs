using Education.Application.Abstractions;
using Education.Application.UseCases.CouponCase.Commands;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CouponCase.Handlers.CommandHandler
{
    public class UpdateCouponHandler : IRequestHandler<UpdateCouponCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;

        public UpdateCouponHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateCouponCommand request, CancellationToken cancellationToken)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(x =>  x.Id == request.Id);
            if (coupon == null)
            {
                return new ResponseModel()
                {
                    Message = "Coupon not found",
                    StatusCode = 404,
                    IsSuccess = true
                };
            }

            var result = new CouponModel()
            {
                CouponCode = request.NewCouponCode,
                Discount = request.NewDiscount
            };

            _context.Coupons.Update(result);
            await _context.SaveChangesAsync();

            return new ResponseModel()
            {
                Message = "Coupon updated",
                StatusCode = 201,
                IsSuccess = true
            };
        }
    }
}
