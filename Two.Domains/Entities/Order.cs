using System;
using System.Collections.Generic;

namespace Boxters.Domain.Entities
{
    public partial class Order
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime OrderedDateTime { get; set; }
        public int OrderStateId { get; set; }
        public int? EmoloyeeId { get; set; }

        public virtual Account Emoloyee { get; set; }
        public virtual OrderState OrderState { get; set; }
        public virtual ICollection<OrderFoodOperation> OrderFoodOperations { get; set; }

    }
}
