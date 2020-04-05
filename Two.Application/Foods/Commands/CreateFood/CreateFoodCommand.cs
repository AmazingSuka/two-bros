using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Foods.Commands.CreateFood
{
    public class CreateFoodCommand : FoodModel
    {
        public IFormFile Image { get; set; }
    }
}
