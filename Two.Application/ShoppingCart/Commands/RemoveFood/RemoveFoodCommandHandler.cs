using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.ShoppingCart.Commands.RemoveFood
{
    public class RemoveFoodCommandHandler : IRequestHandler<RemoveFoodCommand, Unit>
    {
        public Task<Unit> Handle(RemoveFoodCommand request, CancellationToken cancellationToken)
        {
            Cart cart = Cart.FromByteArray(request.Session.Get("Cart"));

            cart.Remove(request.FoodId);
            cart.Save(request.Session);

            return Unit.Task;
        }
    }
}
