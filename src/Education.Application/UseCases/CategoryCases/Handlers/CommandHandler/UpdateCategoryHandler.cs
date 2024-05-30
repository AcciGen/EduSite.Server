using Education.Application.Abstractions;
using Education.Application.UseCases.CategoryCases.Commands;
using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CategoryCases.Handlers.CommandHandler
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;

        public UpdateCategoryHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            if(request is not null)
            {
                var category = _context.Categories.Find(request.Id);
                if(category is not null)
                {
                    category.Name = request.NewName;
                    _context.Categories.Update(category);
                    await _context.SaveChangesAsync();
                }

                return new ResponseModel()
                {
                    Message = "Category updated",
                    StatusCode = 201,
                    IsSuccess = true
                };
            }

            return new ResponseModel()
            {
                Message = "Category not found",
                StatusCode = 404,
                IsSuccess = false
            };
        }
    }
}
