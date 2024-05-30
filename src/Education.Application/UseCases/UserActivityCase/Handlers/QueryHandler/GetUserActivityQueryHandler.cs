using Education.Application.Abstractions;
using Education.Application.UseCases.UserActivityCase.Queries;
using Education.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.UserActivityCase.Handlers.QueryHandler
{
    public class GetUserActivityQueryHandler : IRequestHandler<GetUserActivityQuery, UserActivityModel>
    {
        private readonly IEducationDbContext _context;

        public GetUserActivityQueryHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<UserActivityModel> Handle(GetUserActivityQuery request, CancellationToken cancellationToken)
        {
            var activity = await _context.UserActivityModels.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (activity == null)
            {
                return null!;
            }

            return activity;
        }
    }
}
