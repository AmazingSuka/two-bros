using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.Foods.Queries.GetFoodsList.GetFoodListByCategory
{
    public class GetFoodListByCategoryQueryHandler : IRequestHandler<GetFoodListByCategoryQuery, IEnumerable<FoodLookupModel>>
    {
        public Task<IEnumerable<FoodLookupModel>> Handle(GetFoodListByCategoryQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(request.Items.Where(x => x.Category == request.Category));
        }
    }
}
