using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CategoryCases.Commands
{
    public class DeleteCategoryCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
}
