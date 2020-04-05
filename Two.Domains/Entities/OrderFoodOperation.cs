using System;
using System.Collections.Generic;

namespace Boxters.Domain.Entities
{
    public partial class OrderFoodOperation
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int FoodId { get; set; }
        public short Quantity { get; set; }

        public virtual Food Food { get; set; }
        public virtual Order Order { get; set; }
    }
}
