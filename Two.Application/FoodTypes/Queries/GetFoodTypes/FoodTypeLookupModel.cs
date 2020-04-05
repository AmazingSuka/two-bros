using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.FoodTypes.Queries.GetFoodTypes
{
    public class FoodTypeLookupModel
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public FoodTypeLookupModel(int id, string type)
        {
            Id = id;
            Type = type;
        }
    }
}
