using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.OrderStates.Commands.CreateOrderState
{
    public class CreateOrderStateCommand : IRequest<int>
    {
        public string State { get; set; }
    }
}
