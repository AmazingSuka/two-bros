using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.ShoppingCart.Queries.GetSelectedItems
{ 
    public class GetSelectedItemsQuery : CartRequest, IRequest<IEnumerable<SelectedItemLookupModel>>
    {

    }
}
