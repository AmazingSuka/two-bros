using Boxters.Application.Orders.Queries.GetOrders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Orders.Queries.GetOrders.GetOrderById
{
    public class GetOrderQuery : IRequest<OrderLookupModel>
    {
        public int OrderId { get; set; }
    }
}
