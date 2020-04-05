using Boxters.Application.Foods;
using Boxters.Application.Foods.Commands;
using Boxters.Application.Foods.Commands.CreateFood;
using Boxters.Application.Foods.Queries.GetFoodTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boxters.WebUI.Models
{
    public class CreateFoodViewModel
    {
        public CreateFoodCommand Command { get; set; }
        public IEnumerable<FoodTypeLookupModel> FoodTypes { get; set; }
    }
}
