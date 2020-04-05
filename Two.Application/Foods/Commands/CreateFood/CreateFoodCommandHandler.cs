using Boxters.Application.Interfaces;
using Boxters.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3.Transfer;
using Amazon.S3.Model;
using Amazon.Runtime;
using Amazon.S3;
using Boxters.Application.Infrastructure;

namespace Boxters.Application.Foods.Commands.CreateFood
{
    public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand, Unit>
    {
        private readonly IBoxBoxContext _context;
        public CreateFoodCommandHandler(IBoxBoxContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
        {
            var entity = new Food
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                Weight = request.Weight,
                Size = request.Size,
                Protein = request.Protein,
                Fats = request.Fats,
                Carbohydrates = request.Carbohydrates,
                Calories = request.Calories,
                TypeId = request.TypeId
            };

            if (request.Image != null)
            {
                AmazonS3 amazon = new AmazonS3();

                string filename = amazon.GetRandomFileNameWithPrefix(request.Image.FileName, 100000, 5);
                string path = $"images/food/{filename}";

                await amazon.UploadFoodImage(request.Image, filename);

                entity.ImagePath = path;
                amazon.Dispose();
            }
            else
            {
                entity.ImagePath = "images/food/default.jpg";
            }

            await _context.Food.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}