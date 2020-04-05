using Boxters.Application.Interfaces;
using Boxters.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.FoodTypes.Commands.CreateFoodType
{
    public class CreateFoodTypeCommandHandler : IRequestHandler<CreateFoodTypeCommand, int>
    {
        private IBoxBoxContext dbContext;

        public CreateFoodTypeCommandHandler(IBoxBoxContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Handle(CreateFoodTypeCommand request, CancellationToken cancellationToken)
        {
            FoodType foodType = new FoodType { Type = request.FoodType };
            await dbContext.FoodType.AddAsync(foodType);
            await dbContext.SaveChangesAsync(cancellationToken);

            return foodType.Id;
        }
    }
}
