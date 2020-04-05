using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderLookupModel
    {
        public string ClientName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
