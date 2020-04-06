using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boxters.Application.Infrastructure;
using Boxters.Application.Orders.Commands.ChangeOrderState;
using Boxters.Application.Orders.Commands.CreateOrder;
using Boxters.Application.Orders.Queries.GetOrders;
using Boxters.Application.Orders.Queries.GetOrders.GetOrderById;
using Boxters.Application.Orders.Queries.GetOrders.GetOrdersByState;
using Boxters.Application.OrderStates.Queries.GetOrderStates;
using Boxters.Application.ShoppingCart;
using Boxters.Application.ShoppingCart.Queries.GetSelectedItems;
using Boxters.WebUI.Infrastructure;
using Boxters.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Boxters.WebUI.Controllers
{
    public class OrderController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new CreateOrderViewModel { Items = await Mediator.Send(new GetSelectedItemsQuery { Session = HttpContext.Session }) });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderLookupModel lookupModel)
        {
            int createdOrderId = await Mediator.Send(new CreateOrderCommand { LookupModel = lookupModel, Session = HttpContext.Session });

            return RedirectToAction("Detail", new { id = createdOrderId });
        }

        [HttpGet]
        [Authorize(Roles = Roles.Administrator)]
        public async Task<IActionResult> Index(string targetState)
        {
            IEnumerable<OrderLookupModel> result = await Mediator.Send(new GetOrdersQuery());
            List<StateLookupModel> states = await Mediator.Send(new GetOrderStatesQuery());

            if (targetState != null)
            {
                result = await Mediator.Send(new GetOrdersByStateQuery { Orders = result, TargetState = targetState });
                ViewData["TargetOrderState"] = $"{targetState}";
            }

            OrderViewModel model = new OrderViewModel { 
                Orders = result, 
                States = states 
            };

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = Roles.Administrator)]
        public async Task<IActionResult> ChangeState(string targetState, int orderId)
        {
            await Mediator.Send(new ChangeOrderStateCommand { OrderId = orderId, TargetState = targetState });
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Order/Detail/{id:int}")]
        public async Task<IActionResult> Detail(int id)
        {
            return View(await Mediator.Send(new GetOrderQuery { OrderId = id }));
        }
    }
}
