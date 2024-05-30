// CouponController.cs
using Education.Application.UseCases.CouponCase.Commands;
using Education.Application.UseCases.CouponCase.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CouponController(IMediator mediatr)
        {
            _mediator = mediatr;
        }

        [HttpGet("all")] // Route path: api/Coupon/all
        public async Task<IActionResult> GetCoupons()
        {
            var result = await _mediator.Send(new GetAllCouponQuery());
            return Ok(result);
        }

        [HttpGet("{id}")] // Route path: api/Coupon/{id}
        public async Task<IActionResult> GetCoupon(Guid id)
        {
            var result = await _mediator.Send(new GetCouponByIdQuery() { Id = id});
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon(DeleteCouponCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
