using Boxters.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.OrderStates.Commands.UpdateOrderState
{
    public class UpdateOrderStateCommandHandler : IRequestHandler<UpdateOrderStateCommand, Unit>
    {
        private readonly IBoxBoxContext _context;

        public UpdateOrderStateCommandHandler(IBoxBoxContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateOrderStateCommand request, CancellationToken cancellationToken)
        {
            var state = await _context.OrderState.FindAsync(request.OrderStateId);

            state.State = request.State;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
