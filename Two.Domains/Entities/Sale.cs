using System;
using System.Collections.Generic;

namespace Boxters.Domain.Entities
{
    public partial class Sale
    {
        public Sale()
        {
            SaleFood = new HashSet<SaleFood>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Relevance { get; set; }
        public DateTime BeginningTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Discount { get; set; }

        public virtual ICollection<SaleFood> SaleFood { get; set; }
    }
}
