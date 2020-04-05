using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Foods.Queries.GetFoodIds
{
    public class GetFoodIdsQuery : IRequest<IEnumerable<int>>
    {
    }
}
