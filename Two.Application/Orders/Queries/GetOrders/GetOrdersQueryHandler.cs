using Boxters.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.Orders.Queries.GetOrders
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IEnumerable<OrderLookupModel>>
    {
        private readonly IBoxBoxContext _context;

        public GetOrdersQueryHandler(IBoxBoxContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<OrderLookupModel>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_context.Order
                .Include(o => o.OrderState)
                .Select(x => new OrderLookupModel
                {
                    Id = x.Id,
                    ClientName = x.ClientName,
                    PhoneNumber = x.PhoneNumber,
                    Address = x.Address,
                    OrderState = x.OrderState,
                    OrderedItems = _context.OrderFoodOperation.Where(op => op.OrderId == x.Id).Include(op => op.Food)
                    .Select(op => new OrderedItemLookupModel
                    {
                        OperationId = op.Id,
                        FoodId = op.FoodId,
                        FoodName = op.Food.Name,
                        Quantity = op.Quantity
                    }).ToList()
                }).OrderByDescending(x => x.Id).AsEnumerable());
        }
    }
}
