using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.OrderStates.Commands.UpdateOrderState
{
    public class UpdateOrderStateCommandValidator : AbstractValidator<UpdateOrderStateCommand>
    {
        public UpdateOrderStateCommandValidator()
        {
            RuleFor(x => x.State).NotEmpty();
            RuleFor(x => x.OrderStateId).NotNull();
        }
    }
}
