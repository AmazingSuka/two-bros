using Boxters.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.Foods.Queries.GetFoodTypes
{
    public class GetFoodTypesQueryHandler : IRequestHandler<GetFoodTypesQuery, IEnumerable<FoodTypeLookupModel>>
    {
        private readonly IBoxBoxContext _context;

        public GetFoodTypesQueryHandler(IBoxBoxContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<FoodTypeLookupModel>> Handle(GetFoodTypesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_context.FoodType.Select(x => new FoodTypeLookupModel
            {
                Id = x.Id,
                Type = x.Type
            }).AsEnumerable());
        }
    }
}
