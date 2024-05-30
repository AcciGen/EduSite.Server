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
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;

        public DeleteCategoryHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            if(request is not null)
            {

                var category = _context.Categories.Find(request.Id);

                if(category is null)
                {
                    return new ResponseModel()
                    {
                        Message = "Category not found or Id isn't valid",
                        StatusCode = 404,
                        IsSuccess = false
                    };
                }

                
                _context.Categories.Remove(category);

                await _context.SaveChangesAsync();

                return new ResponseModel()
                {
                    Message = "Category deleted",
                    StatusCode = 200,
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
