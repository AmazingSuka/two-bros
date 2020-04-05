using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Foods.Queries.GetFoodCount
{
    public class GetFoodCountQuery : IRequest<int>
    {
    }
}
