using Boxters.Application.Foods.Commands.UpdateFood;
using Boxters.Application.Foods.Queries.GetFoodDetail;
using Boxters.Application.Foods.Queries.GetFoodTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boxters.WebUI.Models
{
    public class UpdateFoodViewModel
    {
        public FoodDetailModel Current { get; set; }
        public UpdateFoodCommand Command { get; set; }
        public IEnumerable<FoodTypeLookupModel> FoodTypes { get; set; }
    }
}
