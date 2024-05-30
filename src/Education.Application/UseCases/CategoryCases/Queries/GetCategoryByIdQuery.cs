using Education.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CategoryCases.Queries
{
    public class GetCategoryByIdQuery : IRequest<CategoryModel>
    {
        public Guid Id { get; set; }
    }
}
