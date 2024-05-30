using Education.Domain.Entities.Auth;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.UserCases.Commands
{
    public class UpdateUserCommand:IRequest<ResponseModel>
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string? Role { get; set; }

        public IFormFile Photo { get; set; }
        public string Counry { get; set; }
    }
}
