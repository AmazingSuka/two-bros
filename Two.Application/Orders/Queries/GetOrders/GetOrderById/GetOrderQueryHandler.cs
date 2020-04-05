using Boxters.Application.Interfaces;
using Boxters.Application.Orders.Queries.GetOrders;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.Orders.Queries.GetOrders.GetOrderById
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderLookupModel>
    {
        private readonly IBoxBoxContext _context;

        public GetOrderQueryHandler(IBoxBoxContext context)
        {
            _context = context;
        }

        public Task<OrderLookupModel> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = _context.Order.Include(x => x.OrderState).Single(x => x.Id == request.OrderId);

            OrderLookupModel orderLookupModel = new OrderLookupModel
            {
                Id = order.Id,
                ClientName = order.ClientName,
                Address = order.Address,
                PhoneNumber = order.PhoneNumber,
                OrderedItems = _context.OrderFoodOperation
                    .Where(x => x.OrderId == order.Id)
                    .Include(x => x.Food)
                    .Select(x => new OrderedItemLookupModel
                    {
                        OperationId = x.Id,
                        FoodId = x.FoodId,
                        FoodName = x.Food.Name,
                        Quantity = x.Quantity
                    }).ToList(),
                OrderState = order.OrderState
            };

            return Task.FromResult(orderLookupModel);
        }
    }
}
