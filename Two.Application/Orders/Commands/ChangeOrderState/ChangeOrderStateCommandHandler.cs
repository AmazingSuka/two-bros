using Boxters.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.Orders.Commands.ChangeOrderState
{
    public class ChangeOrderStateCommandHandler : IRequestHandler<ChangeOrderStateCommand, Unit>
    {
        private readonly IBoxBoxContext _context;

        public ChangeOrderStateCommandHandler(IBoxBoxContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ChangeOrderStateCommand request, CancellationToken cancellationToken)
        {
            _context.Order.Find(request.OrderId).OrderStateId = _context.OrderState.Single(x => x.State == request.TargetState).Id;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
