using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.ShoppingCart.Queries.GetTotalPrice
{
    public class GetTotalPriceQueryHandler : IRequestHandler<GetTotalPriceQuery, double>
    {
        public Task<double> Handle(GetTotalPriceQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                request.Items.Aggregate(0d, (acc, next) => acc += next.Price * next.Quantity));
        }
    }
}
