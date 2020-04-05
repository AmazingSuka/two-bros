using Amazon;
using Boxters.Application.Exceptions;
using Boxters.Application.Infrastructure;
using Boxters.Application.Interfaces;
using Boxters.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.Foods.Commands.DeleteFood
{
    public class DeleteFoodCommandHandler : IRequestHandler<DeleteFoodCommand, Unit>
    {
        private readonly IBoxBoxContext _context;

        public DeleteFoodCommandHandler(IBoxBoxContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteFoodCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Food.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            string entityImagePath = entity.ImagePath;

            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(Food), request.Id);
            }

            var hasRelations = await _context.SaleFood.AnyAsync(x => x.FoodId == entity.Id);

            if (hasRelations)
            {
                throw new DeleteFailureException(nameof(Food), request.Id, "Deletion entity has related of Sales");
            }

            _context.Food.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            await new AmazonS3().DeleteFoodImageAsync(entityImagePath);

            return Unit.Value;
        }
    }
}
