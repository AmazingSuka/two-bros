using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Foods.Queries.GetFoodTypes
{
    public class FoodTypeLookupModel : IFoodRequest
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
