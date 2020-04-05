using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.Orders.Queries.GetOrders.GetOrdersByState
{
    public class GetOrdersByStateQueryHandler : IRequestHandler<GetOrdersByStateQuery, IEnumerable<OrderLookupModel>>
    {
        public Task<IEnumerable<OrderLookupModel>> Handle(GetOrdersByStateQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(request.Orders.Where(o => o.OrderState.State == request.TargetState));
        }
    }
}
