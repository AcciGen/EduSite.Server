using Education.Application.Abstractions;
using Education.Application.UseCases.MessageCases.Command;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Application.UseCases.MessageCases.Handlers.CommandHandlers
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;
        private readonly IHubContext<Hubs> _hubContext;

        public CreateMessageCommandHandler(IEducationDbContext context, IHubContext<Hubs> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        public async Task<ResponseModel> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = new MessageModel()
            {
                Message = request.Message,
                GroupId = request.GoupId,
                SenderId = request.SenderId.ToString()
            };

            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync(cancellationToken);

            await _hubContext.Clients.Group(request.GoupId.ToString()).SendAsync("ReceiveMessage", message, request.SenderId);

            return new ResponseModel()
            {
                Message = "Successfully Created",
                StatusCode = 201,
                IsSuccess = true
            };
        }
    }
}
