using System;
using System.Collections.Generic;

namespace Boxters.Domain.Entities
{
    public partial class FoodType
    {
        public FoodType()
        {
            Food = new HashSet<Food>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Food> Food { get; set; }
    }
}
