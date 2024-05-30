using Education.Application.Abstractions;
using Education.Application.UseCases.CategoryCases.Queries;
using Education.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CategoryCases.Handlers.QueryHandler
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryModel>>
    {
        private readonly IEducationDbContext _context;

        public GetAllCategoryQueryHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryModel>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Categories.ToListAsync();

            if(result is null)
            {
                throw new Exception("Category not found");
            }

            return result;
        }
    }
}
