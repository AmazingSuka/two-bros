using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.LookupModel).NotNull();
            RuleFor(x => x.Session).NotNull();
        }
    }
}
