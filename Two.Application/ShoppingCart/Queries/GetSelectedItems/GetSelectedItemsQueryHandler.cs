using Boxters.Application.Interfaces;
using Boxters.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.ShoppingCart.Queries.GetSelectedItems
{
    public class GetSelectedItemsQueryHandler : IRequestHandler<GetSelectedItemsQuery, IEnumerable<SelectedItemLookupModel>>
    {
        private IBoxBoxContext _context;

        public GetSelectedItemsQueryHandler(IBoxBoxContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<SelectedItemLookupModel>> Handle(GetSelectedItemsQuery request, CancellationToken cancellationToken)
        {
            Cart cart = Cart.FromByteArray(request.Session.Get("Cart"));
            IList<SelectedItemLookupModel> lookupModels = new List<SelectedItemLookupModel>();
            IList<int> DeletedItems = new List<int>(); 

            foreach (int item in cart.GetKeys())
            {
                Food food = _context.Food.Find(item);

                if (food != null)
                {
                    lookupModels.Add(new SelectedItemLookupModel
                    {
                        Id = food.Id,
                        Name = food.Name,
                        Price = food.Price,
                        Size = food.Size,
                        Weight = food.Weight,
                        Quantity = cart.GetQuantity(item),
                        ImagePath = food.ImagePath,
                        FullPrice = food.Price * cart.GetQuantity(item)
                    }); 
                }
                else
                {
                    // Add deleted items in special list
                    DeletedItems.Add(item);
                }

            }

            if (DeletedItems.Count > 0)
            {
                // Remove all deleted items from cart
                foreach (var item in DeletedItems)
                {
                    cart.Set(item, 0);
                }

                // Save changes in session
                cart.Save(request.Session);
            }

            return Task.FromResult(lookupModels.AsEnumerable());
        }
    }
}
