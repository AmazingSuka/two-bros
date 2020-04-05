using Boxters.Application.Infrastructure;
using Boxters.Application.OrderStates.Commands.CreateOrderState;
using Boxters.Application.OrderStates.Commands.DeleteOrderState;
using Boxters.Application.OrderStates.Commands.UpdateOrderState;
using Boxters.Application.OrderStates.Queries.GetOrderStates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boxters.WebUI.Controllers
{
    [Authorize(Roles = Roles.Administrator)]
    public class OrderStateController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await Mediator.Send(new GetOrderStatesQuery()));
        }

        [HttpPost]
        public async Task<int> Create(string value)
        {
            return await Mediator.Send(new CreateOrderStateCommand { State = value });
        }

        [HttpPost]
        public async Task Update(int id, string value)
        {
            await Mediator.Send(new UpdateOrderStateCommand { OrderStateId = id, State = value });
        }

        [HttpPost]
        public async Task Delete(int id)
        {
            await Mediator.Send(new DeleteOrderStateCommand { OrderStateId = id });
        }
    }
}
