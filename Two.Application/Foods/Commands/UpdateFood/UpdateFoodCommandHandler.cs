using Boxters.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Boxters.Application.Exceptions;
using Boxters.Domain.Entities;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon;
using Boxters.Application.Infrastructure;

namespace Boxters.Application.Foods.Commands.UpdateFood
{
    public class UpdateFoodCommandHandler : IRequestHandler<UpdateFoodCommand, Unit>
    {
        private readonly IBoxBoxContext _context;
        public UpdateFoodCommandHandler(IBoxBoxContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateFoodCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Food.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(Food), request.Id);
            }

            entity.Name = request.Name;
            entity.Price = request.Price;
            entity.Description = request.Description;
            entity.Weight = request.Weight;
            entity.Size = request.Size;
            entity.Protein = request.Protein;
            entity.Fats = request.Fats;
            entity.Carbohydrates = request.Carbohydrates;
            entity.Calories = request.Calories;
            entity.TypeId = request.TypeId;

            if (request.Image != null)
            {
                AmazonS3 amazon = new AmazonS3();

                string filename = amazon.GetRandomFileNameWithPrefix(request.Image.FileName, 100000, 5);
                string path = $"images/food/{filename}";

                await amazon.DeleteFoodImageAsync(entity.ImagePath);
                await amazon.UploadFoodImage(request.Image, filename);

                entity.ImagePath = path;
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
