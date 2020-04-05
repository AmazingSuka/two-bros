using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Foods.Commands.DeleteFood
{
    public class DeleteFoodCommand : IFoodRequest
    {
        public int Id { get; set; }
    }
}
