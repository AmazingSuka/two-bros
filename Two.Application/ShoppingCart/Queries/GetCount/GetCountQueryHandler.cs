using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.ShoppingCart.Queries.GetCount
{
    public class GetCountQueryHandler : IRequestHandler<GetCountQuery, int>
    {
        public Task<int> Handle(GetCountQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Cart.FromByteArray(request.Session.Get("Cart")).Count());
        }
    }
}
