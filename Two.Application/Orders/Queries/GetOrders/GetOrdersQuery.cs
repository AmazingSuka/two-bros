using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Orders.Queries.GetOrders
{
    public class GetOrdersQuery : IRequest<IEnumerable<OrderLookupModel>>
    {

    }
}
