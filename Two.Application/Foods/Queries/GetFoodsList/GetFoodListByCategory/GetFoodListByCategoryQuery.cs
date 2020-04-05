using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Foods.Queries.GetFoodsList.GetFoodListByCategory
{
    public class GetFoodListByCategoryQuery : IRequest<IEnumerable<FoodLookupModel>>
    {
        public IEnumerable<FoodLookupModel> Items { get; set; }
        public string Category { get; set; }
    }
}
