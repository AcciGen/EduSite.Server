using Education.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.WishListCases.Queries
{
    public class GetAllCourseFromWishListQuery:IRequest<List<CourseModel>>
    {
        public string UserId {  get; set; }
    }
}
