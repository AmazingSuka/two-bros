using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Foods.Commands.DeleteFood
{
    class DeleteFoodCommandValidator : AbstractValidator<DeleteFoodCommand>
    {
        public DeleteFoodCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
