using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.ShoppingCart.Queries.GetSelectedItems
{
    public class SelectedItemLookupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public short Size { get; set; }
        public short Quantity { get; set; }
        public string ImagePath { get; set; }
        public double FullPrice { get; set; }
    }
}
