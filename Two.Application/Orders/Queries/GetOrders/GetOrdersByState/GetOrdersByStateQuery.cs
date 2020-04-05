using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Orders.Queries.GetOrders.GetOrdersByState
{
    public class GetOrdersByStateQuery : IRequest<IEnumerable<OrderLookupModel>>
    {
        public string TargetState { get; set; }
        public IEnumerable<OrderLookupModel> Orders { get; set; }
    }
}
