using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Orders.Commands.ChangeOrderState
{
    public class ChangeOrderStateCommand : IRequest
    {
        public int OrderId { get; set; }
        public string TargetState { get; set; }
    }
}
