using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.OrderStates.Queries.GetOrderStates
{
    public class GetOrderStatesQuery : IRequest<List<StateLookupModel>>
    {

    }
}
