using Boxters.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Foods
{
    public abstract class FoodModel : IFoodRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public short Size { get; set; }
        public short Protein { get; set; }
        public short Fats { get; set; }
        public short Carbohydrates { get; set; }
        public short Calories { get; set; }
        public int TypeId { get; set; }
    }
}
