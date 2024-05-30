using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.WishListCases.Commands
{
    public class AddToWishListCommand : IRequest<ResponseModel>
    {
        public string UserId { get; set; }
        public Guid CourseId { get; set; }
    }
}
