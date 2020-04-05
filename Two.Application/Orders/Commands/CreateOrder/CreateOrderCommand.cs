using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<int>
    {
        public CreateOrderLookupModel LookupModel { get; set; }
        public ISession Session { get; set; }
    }
}
