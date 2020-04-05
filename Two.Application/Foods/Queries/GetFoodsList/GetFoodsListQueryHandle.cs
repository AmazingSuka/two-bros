using Boxters.Application.Interfaces;
using Boxters.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.Foods.Queries.GetFoodsList
{
    class GetFoodsListQueryHandle : IRequestHandler<GetFoodsListQuery, IEnumerable<FoodLookupModel>>
    {
        private readonly IBoxBoxContext _context;

        public GetFoodsListQueryHandle(IBoxBoxContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<FoodLookupModel>> Handle(GetFoodsListQuery request, CancellationToken cancellationToken)
        {

            return Task.FromResult(_context.Food.Select(x => new FoodLookupModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Description = x.Description,
                Weight = x.Weight,
                Size = x.Size,
                Category = x.Type.Type,
                ImagePath = x.ImagePath
            }).OrderBy(x => x.Name).AsEnumerable());
        }
    }
}
