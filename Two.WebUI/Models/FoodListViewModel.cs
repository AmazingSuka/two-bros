using Boxters.Application.Foods.Queries.GetFoodsList;
using Boxters.Application.Foods.Queries.GetFoodTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boxters.WebUI.Models
{
    public class FoodListViewModel
    {
        public IEnumerable<FoodLookupModel> FoodList { get; set; }
        public IEnumerable<FoodTypeLookupModel> FoodTypes { get; set; }
    }
}
