using Education.Domain.Entities.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.UserCases.Queries
{
    public class GetUserByIdQuery:IRequest<UserModel>
    {
        public Guid Id { get; set; }
    }
}
