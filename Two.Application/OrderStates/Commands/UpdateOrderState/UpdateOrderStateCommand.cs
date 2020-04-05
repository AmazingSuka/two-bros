using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.OrderStates.Commands.UpdateOrderState
{
    public class UpdateOrderStateCommand : IRequest
    {
        public int OrderStateId { get; set; }
        public string State { get; set; }
    }
}
