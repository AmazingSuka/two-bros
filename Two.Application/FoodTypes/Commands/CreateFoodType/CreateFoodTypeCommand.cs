using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.FoodTypes.Commands.CreateFoodType
{
    public class CreateFoodTypeCommand : IRequest<int>
    {
        public string FoodType { get; private set; }

        public CreateFoodTypeCommand(string foodType)
        {
            FoodType = foodType;
        }
    }
}
