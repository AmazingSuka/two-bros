using Boxters.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.Foods.Queries.GetFoodIds
{
    public class GetFoodIdsQueryHandler : IRequestHandler<GetFoodIdsQuery, IEnumerable<int>>
    {
        private IBoxBoxContext _context;
        public GetFoodIdsQueryHandler(IBoxBoxContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<int>> Handle(GetFoodIdsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_context.Food.Select(x => x.Id).AsEnumerable());
        }
    }
}
