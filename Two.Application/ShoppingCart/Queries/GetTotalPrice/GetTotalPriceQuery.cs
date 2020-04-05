using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Boxters.Application.ShoppingCart.Queries.GetSelectedItems;

namespace Boxters.Application.ShoppingCart.Queries.GetTotalPrice
{
    public class GetTotalPriceQuery : IRequest<double>
    {
        public IEnumerable<SelectedItemLookupModel> Items { get; set; }
    }
}
