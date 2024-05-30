using Education.Application.Abstractions;
using Education.Application.UseCases.CategoryCases.Commands;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CategoryCases.Handlers.CommandHandler
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;

        public CreateCategoryHandler(IEducationDbContext context)
        {
            _context = context;
        }


        public async Task<ResponseModel> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (request is not null)
            {
                var category = new CategoryModel()
                {
                    Name = request.Name,
                };

                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();

                return new ResponseModel()
                {
                    Message = "Category created successfully",
                    StatusCode = 201,
                    IsSuccess = true
                };
            }
            return new ResponseModel()
            {
                Message = "Category not created",
                StatusCode = 400,
                IsSuccess = false
            };
        }
    }
}

