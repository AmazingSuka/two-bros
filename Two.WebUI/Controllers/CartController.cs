using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Boxters.Application.ShoppingCart.Commands.AddFood;
using Microsoft.AspNetCore.Http;
using Boxters.Application.ShoppingCart;
using Boxters.Application.ShoppingCart.Commands.RemoveFood;
using Boxters.Application.ShoppingCart.Queries.GetCount;
using Boxters.Application.ShoppingCart.Queries.GetQuantity;
using Boxters.Application.ShoppingCart.Commands.SetFood;
using Boxters.Application.ShoppingCart.Queries.GetSelectedItems;
using Boxters.Application.ShoppingCart.Queries.GetTotalPrice;

namespace Boxters.WebUI.Controllers
{
    public class CartController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await Mediator.Send(new GetSelectedItemsQuery { Session = HttpContext.Session }));   
        }

        [HttpGet]
        public async Task Set(int foodId, int q)
        {
            await Mediator.Send(new SetFoodCommand { FoodId = foodId, Session = HttpContext.Session, Quantity = q });
        }

        [HttpGet]
        public async Task Increment(int foodId)
        {
            await Mediator.Send(new AddFoodCommand { FoodId = foodId, Session = HttpContext.Session});
        }

        [HttpGet]
        public async Task Decrement(int foodId)
        {
            await Mediator.Send(new RemoveFoodCommand { FoodId = foodId, Session = HttpContext.Session });
        }

        [HttpGet]
        public async Task<int> Count()
        {
            return await Mediator.Send(new GetCountQuery { Session = HttpContext.Session });
        }

        [HttpGet]
        public async Task<short> Quantity(int foodId)
        {
            return await Mediator.Send(new GetQuantityQuery { FoodId = foodId, Session = HttpContext.Session });
        }

        [HttpGet]
        public async Task<double> Total()
        {
            return await Mediator.Send(new GetTotalPriceQuery
            {
                Items = await Mediator.Send(new GetSelectedItemsQuery { Session = HttpContext.Session })
            });
        }
    }
}