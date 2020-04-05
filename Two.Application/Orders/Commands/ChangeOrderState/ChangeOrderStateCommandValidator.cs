using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Orders.Commands.ChangeOrderState
{
    public class ChangeOrderStateCommandValidator : AbstractValidator<ChangeOrderStateCommand>
    {
        public ChangeOrderStateCommandValidator()
        {
            RuleFor(x => x.OrderId).NotNull();
            RuleFor(x => x.TargetState).NotNull();
        }
    }
}
