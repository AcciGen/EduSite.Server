using Education.Application.Abstractions;
using Education.Application.UseCases.CategoryCases.Queries;
using Education.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CategoryCases.Handlers.QueryHandler
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryModel>
    {
        private readonly IEducationDbContext _context;

        public GetCategoryByIdQueryHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryModel> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (result != null)
            {
                return result;
            }

            return null!;
        }
    }
}
