using System;
using System.Collections.Generic;

namespace Boxters.Domain.Entities
{
    public partial class Food
    {
        public Food()
        {
            SaleFood = new HashSet<SaleFood>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public short Size { get; set; }
        public short Protein { get; set; }
        public short Fats { get; set; }
        public short Carbohydrates { get; set; }
        public short Calories { get; set; }
        public int TypeId { get; set; }
        public string ImagePath { get; set; }

        public virtual FoodType Type { get; set; }
        public virtual ICollection<SaleFood> SaleFood { get; set; }
        public virtual ICollection<OrderFoodOperation> OrderFoodOperations { get; set; }
    }
}
