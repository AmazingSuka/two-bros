using Boxters.Application.Orders.Commands.CreateOrder;
using Boxters.Application.ShoppingCart.Queries.GetSelectedItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boxters.WebUI.Models
{
    public class CreateOrderViewModel
    {
        public CreateOrderLookupModel lookupModel { get; set; }
        public IEnumerable<SelectedItemLookupModel> Items { get; set; }
    }
}
