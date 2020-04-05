using Boxters.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.OrderStates.Commands.DeleteOrderState
{
    public class DeleteOrderStateCommandHandler : IRequestHandler<DeleteOrderStateCommand, Unit>
    {
        private readonly IBoxBoxContext _context;

        public DeleteOrderStateCommandHandler(IBoxBoxContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteOrderStateCommand request, CancellationToken cancellationToken)
        {
            _context.OrderState.Remove(await _context.OrderState.FindAsync(request.OrderStateId));

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
