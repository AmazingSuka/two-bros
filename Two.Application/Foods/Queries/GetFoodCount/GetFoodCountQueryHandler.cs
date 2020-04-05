using Boxters.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.Foods.Queries.GetFoodCount
{
    public class GetFoodCountQueryHandler : IRequestHandler<GetFoodCountQuery, int>
    {
        private readonly IBoxBoxContext _context;

        public GetFoodCountQueryHandler(IBoxBoxContext context)
        {
            _context = context;
        }

        public Task<int> Handle(GetFoodCountQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_context.Food.Count());
        }
    }
}
