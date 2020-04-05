using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Foods.Queries.GetFoodsList
{
    public class GetFoodsListQuery : IRequest<IEnumerable<FoodLookupModel>>
    {

    }
}
