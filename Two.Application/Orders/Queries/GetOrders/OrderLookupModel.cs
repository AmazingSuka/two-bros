using Boxters.Domain.Entities;
using System.Collections.Generic;

namespace Boxters.Application.Orders.Queries.GetOrders
{
    public class OrderLookupModel
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public OrderState OrderState { get; set; }
        public IList<OrderedItemLookupModel> OrderedItems { get; set; }
    }
}
