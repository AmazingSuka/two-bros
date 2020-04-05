using Boxters.Application.Interfaces;
using Boxters.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.FoodTypes.Commands.DeleteFoodType
{
    public class DeleteFoodTypeCommandHandler : IRequestHandler<DeleteFoodTypeCommand, Unit>
    {
        private IBoxBoxContext dbContext;

        public DeleteFoodTypeCommandHandler(IBoxBoxContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteFoodTypeCommand request, CancellationToken cancellationToken)
        {
            FoodType foodType = await dbContext.FoodType.FindAsync(request.Id);
            dbContext.FoodType.Remove(foodType);
            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
