using Boxters.Application.Orders.Queries.GetOrders;
using Boxters.Application.OrderStates.Queries.GetOrderStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boxters.WebUI.Models
{
    public class OrderViewModel
    {
        public IEnumerable<OrderLookupModel> Orders { get; set; }
        public List<StateLookupModel> States { get; set; }
    }
}
