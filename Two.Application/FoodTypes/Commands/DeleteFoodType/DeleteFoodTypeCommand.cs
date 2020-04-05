using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.FoodTypes.Commands.DeleteFoodType
{
    public class DeleteFoodTypeCommand : IRequest
    {
        public int Id { get; private set; }

        public DeleteFoodTypeCommand(int id)
        {
            Id = id;
        }
    }
}
