using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.ShoppingCart.Commands.SetFood
{
    public class SetFoodCommand : DefaultCartCommand
    {
        public int Quantity { get; set; }
    }
}
