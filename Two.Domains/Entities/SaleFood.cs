using System;
using System.Collections.Generic;

namespace Boxters.Domain.Entities
{
    public partial class SaleFood
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public int SaleId { get; set; }

        public virtual Food Food { get; set; }
        public virtual Sale Sale { get; set; }
    }
}
