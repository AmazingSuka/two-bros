using Boxters.Application.Interfaces;
using Boxters.Application.ShoppingCart;
using Boxters.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IBoxBoxContext _context;

        public CreateOrderCommandHandler(IBoxBoxContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Order order = new Order
                    {
                        ClientName = request.LookupModel.ClientName,
                        PhoneNumber = request.LookupModel.PhoneNumber,
                        Address = request.LookupModel.Address,
                        OrderedDateTime = DateTime.Now,
                        OrderStateId = 1
                    };

                    await _context.Order.AddAsync(order);
                    await _context.SaveChangesAsync(cancellationToken);

                    Cart cart = Cart.FromByteArray(request.Session.Get("Cart"));

                    foreach (var item in cart.GetKeys())
                    {
                        await _context.OrderFoodOperation.AddAsync(new OrderFoodOperation
                        {
                            FoodId = item,
                            Quantity = cart.GetQuantity(item),
                            OrderId = order.Id
                        });
                    }

                    request.Session.Set("Cart", new Cart().ToByteArray());

                    await _context.SaveChangesAsync(cancellationToken);
                    transaction.Commit();

                    return order.Id;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }                
            }
        }
    }
}
