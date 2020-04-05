using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.ShoppingCart.Commands
{
    public class DefaultCartCommandValidator : AbstractValidator<DefaultCartCommand>
    {
        public DefaultCartCommandValidator()
        {
            RuleFor(x => x.FoodId).GreaterThan(0);
        }
    }
}
