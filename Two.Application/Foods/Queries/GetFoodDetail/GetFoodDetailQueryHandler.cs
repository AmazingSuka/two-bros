using Boxters.Application.Exceptions;
using Boxters.Application.Interfaces;
using Boxters.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.Foods.Queries.GetFoodDetail
{
    public class GetFoodDetailQueryHandler : IRequestHandler<GetFoodDetailQuery, FoodDetailModel>
    {
        private readonly IBoxBoxContext _context;

        public GetFoodDetailQueryHandler(IBoxBoxContext context)
        {
            _context = context;
        }

        public async Task<FoodDetailModel> Handle(GetFoodDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Food.FindAsync(request.Id);

            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(Food), request.Id);
            }

            var model = new FoodDetailModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                Weight = entity.Weight,
                Size = entity.Size,
                Calories = entity.Calories,
                Carbohydrates = entity.Carbohydrates,
                Fats = entity.Fats,
                Protein = entity.Protein,
                TypeId = entity.TypeId,
                ImagePath = entity.ImagePath
            };

            return model;
        }
    }
}
