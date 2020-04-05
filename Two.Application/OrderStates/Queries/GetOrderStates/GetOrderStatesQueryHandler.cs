using Boxters.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.OrderStates.Queries.GetOrderStates
{
    public class GetOrderStatesQueryHandler : IRequestHandler<GetOrderStatesQuery, List<StateLookupModel>>
    {
        private readonly IBoxBoxContext _context;

        public GetOrderStatesQueryHandler(IBoxBoxContext context)
        {
            _context = context;
        }

        public Task<List<StateLookupModel>> Handle(GetOrderStatesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_context.OrderState.Select(x => new StateLookupModel { Id = x.Id, State = x.State }).OrderBy(x => x.Id).ToList());
        }
    }
}
