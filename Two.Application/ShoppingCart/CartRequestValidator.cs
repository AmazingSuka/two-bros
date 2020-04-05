using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.ShoppingCart
{
    public class CartRequestValidator : AbstractValidator<CartRequest>
    {
        public CartRequestValidator()
        {
            RuleFor(x => x.Session).NotNull();
        }
    }
}
