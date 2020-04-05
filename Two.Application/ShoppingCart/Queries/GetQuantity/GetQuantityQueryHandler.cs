using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.ShoppingCart.Queries.GetQuantity
{
    public class GetQuantityQueryHandler : IRequestHandler<GetQuantityQuery, short>
    {
        public Task<short> Handle(GetQuantityQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Cart.FromByteArray(request.Session.Get("Cart")).GetQuantity(request.FoodId));
        }
    }
}
