using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.ShoppingCart.Commands.SetFood
{
    public class SetFoodCommandHandler : IRequestHandler<SetFoodCommand, Unit>
    {
        public Task<Unit> Handle(SetFoodCommand request, CancellationToken cancellationToken)
        {
            Cart cart = Cart.FromByteArray(request.Session.Get("Cart"));

            cart.Set(request.FoodId, (short)request.Quantity);
            cart.Save(request.Session);

            return Unit.Task;
        }
    }
}
