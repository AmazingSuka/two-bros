using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.OrderStates.Commands.DeleteOrderState
{
    public class DeleteOrderStateCommand : IRequest
    {
        public int OrderStateId { get; set; }
    }
}
