using Boxters.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Foods.Commands.UpdateFood
{
    public class UpdateFoodCommand : FoodModel
    {
        public IFormFile Image { get; set; }
    }
}
