using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boxters.Application.FoodTypes.Commands.CreateFoodType;
using Boxters.Application.FoodTypes.Commands.DeleteFoodType;
using Boxters.Application.FoodTypes.Commands.UpdateFoodType;
using Boxters.Application.FoodTypes.Queries.GetFoodTypes;
using Boxters.Application.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Boxters.WebUI.Controllers
{
    [Authorize(Roles = Roles.Administrator)]
    public class FoodTypeController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            return View(await Mediator.Send(new GetFoodTypesCommand()));
        }

        [HttpPost]
        public async Task<int> Create(string value)
        {
            return await Mediator.Send(new CreateFoodTypeCommand(value));
        }

        [HttpPost]
        public async Task Update(int id, string value)
        {
            await Mediator.Send(new UpdateFoodTypeCommand(id, value));
        }

        [HttpPost]
        public async Task Delete(int id)
        {
            await Mediator.Send(new DeleteFoodTypeCommand(id));
        }
    }
}