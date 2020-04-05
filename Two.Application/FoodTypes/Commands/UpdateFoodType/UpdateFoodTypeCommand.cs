using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.FoodTypes.Commands.UpdateFoodType
{
    public class UpdateFoodTypeCommand : IRequest
    {
        public int Id { get; private set; }
        public string FoodType { get; private set; }

        public UpdateFoodTypeCommand(int id, string foodType)
        {
            Id = id;
            FoodType = foodType;
        }
    }
}
