using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.OrderStates.Commands.DeleteOrderState
{
    public class DeleteOrderStateCommandValidator : AbstractValidator<DeleteOrderStateCommand>
    {
        public DeleteOrderStateCommandValidator()
        {
            RuleFor(x => x.OrderStateId).NotNull();
        }
    }
}
