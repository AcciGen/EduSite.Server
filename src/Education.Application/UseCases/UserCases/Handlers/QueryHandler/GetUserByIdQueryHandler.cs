using Education.Application.Abstractions;
using Education.Application.UseCases.UserCases.Queries;
using Education.Domain.Entities.Auth;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.UserCases.Handlers.QueryHandler
{
    public class GetUserByIdQueryHandler:IRequestHandler<GetUserByIdQuery,UserModel>
    {
        private readonly IEducationDbContext _context;
        public GetUserByIdQueryHandler(IEducationDbContext context)
        {
            _context = context;   
        }
        public async Task<UserModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id.ToString() );
            if(res == null)
            {
                throw new Exception("User not found");
            }
            return res;

        }
    }
}
