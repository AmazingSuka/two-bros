using Boxters.Application.Interfaces;
using Boxters.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.OrderStates.Commands.CreateOrderState
{
    public class CreateOrderStateCommandHandler : IRequestHandler<CreateOrderStateCommand, int>
    {
        private readonly IBoxBoxContext _context;

        public CreateOrderStateCommandHandler(IBoxBoxContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateOrderStateCommand request, CancellationToken cancellationToken)
        {
            OrderState orderState = new OrderState { State = request.State };
            await _context.OrderState.AddAsync(orderState);
            await _context.SaveChangesAsync(cancellationToken);

            return orderState.Id;
        }
    }
}
