using System.Collections.Generic;
using System.Threading.Tasks;
using Boxters.Application.Foods.Commands.DeleteFood;
using Boxters.Application.Foods.Queries.GetFoodCount;
using Boxters.Application.Foods.Queries.GetFoodDetail;
using Boxters.Application.Foods.Queries.GetFoodIds;
using Boxters.Application.Foods.Queries.GetFoodTypes;
using Boxters.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Boxters.WebUI.Controllers
{
    public class FoodController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Detail(int foodId)
        {
            return PartialView("_FoodDetailPartial", await Mediator.Send(new GetFoodDetailQuery { Id = foodId }));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new CreateFoodViewModel { FoodTypes = await Mediator.Send(new GetFoodTypesQuery()) });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFoodViewModel foodViewModel)
        {
            await Mediator.Send(foodViewModel.Command);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int foodId)
        {
            FoodDetailModel current = await Mediator.Send(new GetFoodDetailQuery { Id = foodId });
            IEnumerable<FoodTypeLookupModel> types = await Mediator.Send(new GetFoodTypesQuery());

            return View(new UpdateFoodViewModel { Current = current, FoodTypes = types });
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateFoodViewModel viewModel)
        {
            await Mediator.Send(viewModel.Command);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int foodId)
        {
            await Mediator.Send(new DeleteFoodCommand { Id = foodId });

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<int> Count()
        {
            return await Mediator.Send(new GetFoodCountQuery());
        }

        [HttpGet]
        public async Task<IEnumerable<int>> All()
        {
            return await Mediator.Send(new GetFoodIdsQuery());
        }

        [HttpGet]
        public async Task<IEnumerable<FoodTypeLookupModel>> FoodTypes()
        {
            return await Mediator.Send(new GetFoodTypesQuery());
        }
    }
}
