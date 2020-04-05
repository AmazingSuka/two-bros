using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.ShoppingCart.Commands.AddFood
{
    public class AddFoodCommandHandler : IRequestHandler<AddFoodCommand, Unit>
    {
        public Task<Unit> Handle(AddFoodCommand request, CancellationToken cancellationToken)
        {
            Cart cart = Cart.FromByteArray(request.Session.Get("Cart"));

            cart.Add(request.FoodId);

            cart.Save(request.Session);

            return Unit.Task;
        }
    }
}
