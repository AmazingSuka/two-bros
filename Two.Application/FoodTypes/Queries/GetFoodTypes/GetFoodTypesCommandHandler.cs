using Boxters.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.FoodTypes.Queries.GetFoodTypes
{
    public class GetFoodTypesCommandHandler : IRequestHandler<GetFoodTypesCommand, IEnumerable<FoodTypeLookupModel>>
    {
        private IBoxBoxContext dbContext;

        public GetFoodTypesCommandHandler(IBoxBoxContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<IEnumerable<FoodTypeLookupModel>> Handle(GetFoodTypesCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(dbContext.FoodType.Select(x => new FoodTypeLookupModel(x.Id, x.Type)).AsEnumerable());
        }
    }
}
