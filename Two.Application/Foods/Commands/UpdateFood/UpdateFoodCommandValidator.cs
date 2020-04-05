using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Foods.Commands.UpdateFood
{
    public class UpdateFoodCommandValidator : AbstractValidator<UpdateFoodCommand>
    {
        public UpdateFoodCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(3).MaximumLength(50).NotEmpty();
            RuleFor(x => x.Price).GreaterThan(0).NotEmpty();
            RuleFor(x => x.Description).MaximumLength(200).NotEmpty();
            RuleFor(x => x.Weight).GreaterThan(0).NotEmpty();
            RuleFor(x => x.Size).GreaterThan((short)0).NotEmpty();
            RuleFor(x => x.Protein).GreaterThan((short)0).NotEmpty();
            RuleFor(x => x.Fats).GreaterThan((short)0).NotEmpty();
            RuleFor(x => x.Carbohydrates).GreaterThan((short)0).NotEmpty();
            RuleFor(x => x.Calories).GreaterThan((short)0).NotEmpty();
            RuleFor(x => x.TypeId).NotEmpty();
        }
    }
}
