using System;
using System.Collections.Generic;

namespace Boxters.Domain.Entities
{
    public partial class OrderState
    {
        public OrderState()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string State { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
