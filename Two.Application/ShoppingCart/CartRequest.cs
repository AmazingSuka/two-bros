using Boxters.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.ShoppingCart
{
    public abstract class CartRequest
    {
        public ISession Session { get; set; }
    }
}
