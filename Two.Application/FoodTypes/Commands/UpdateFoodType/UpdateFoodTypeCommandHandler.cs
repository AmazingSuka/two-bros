using Boxters.Application.Interfaces;
using Boxters.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.FoodTypes.Commands.UpdateFoodType
{
    public class UpdateFoodTypeCommandHandler : IRequestHandler<UpdateFoodTypeCommand, Unit>
    {
        private IBoxBoxContext dbContext;

        public UpdateFoodTypeCommandHandler(IBoxBoxContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateFoodTypeCommand request, CancellationToken cancellationToken)
        {
            FoodType foodType = await dbContext.FoodType.FindAsync(request.Id);
            foodType.Type = request.FoodType;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
