using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.FoodTypes.Queries.GetFoodTypes
{
    public class GetFoodTypesCommand : IRequest<IEnumerable<FoodTypeLookupModel>>
    {
    }
}
