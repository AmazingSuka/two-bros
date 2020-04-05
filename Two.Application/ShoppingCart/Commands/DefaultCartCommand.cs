using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.ShoppingCart.Commands
{
    public abstract class DefaultCartCommand : CartRequest, IRequest
    {
        public int FoodId { get; set; }
    }
}
