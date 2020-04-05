using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Foods.Queries.GetFoodTypes
{
    public class GetFoodTypesQuery : IRequest<IEnumerable<FoodTypeLookupModel>>
    {

    }
}
