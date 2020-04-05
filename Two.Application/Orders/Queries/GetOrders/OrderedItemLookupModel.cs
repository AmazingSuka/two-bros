using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Orders.Queries.GetOrders
{
    public class OrderedItemLookupModel
    {
        public int OperationId { get; set; }
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public short Quantity { get; set; }
    }
}
