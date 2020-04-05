using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.ShoppingCart.Commands.SetFood
{
    public class SetFoodCommandValidator : AbstractValidator<SetFoodCommand>
    {
        public SetFoodCommandValidator()
        {
            RuleFor(x => x.Quantity).NotNull().GreaterThanOrEqualTo(0);
        }
    }
}
