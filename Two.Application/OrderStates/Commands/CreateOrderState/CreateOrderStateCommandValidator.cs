using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.OrderStates.Commands.CreateOrderState
{
    public class CreateOrderStateCommandValidator : AbstractValidator<CreateOrderStateCommand>
    {
        public CreateOrderStateCommandValidator()
        {
            RuleFor(x => x.State).NotEmpty();
        }
    }
}
