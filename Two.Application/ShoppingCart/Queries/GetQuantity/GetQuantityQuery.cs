using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.ShoppingCart.Queries.GetQuantity
{
    public class GetQuantityQuery : CartRequest, IRequest<short>
    {
        public int FoodId { get; set; }
    }
}
