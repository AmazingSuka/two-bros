using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Boxters.WebUI.Models;
using Boxters.Application.Foods.Queries.GetFoodsList;
using Boxters.Application.Foods.Queries.GetFoodDetail;
using Boxters.Application.Foods.Commands.UpdateFood;
using Boxters.Application.Foods.Commands.DeleteFood;
using Boxters.Application.Foods.Queries.GetFoodTypes;
using Boxters.Application.Foods.Queries.GetFoodsList.GetFoodListByCategory;

namespace Boxters.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index(string category)
        {
            FoodListViewModel foodListViewModel = new FoodListViewModel
            {
                FoodList = await Mediator.Send(new GetFoodsListQuery()),
                FoodTypes = await Mediator.Send(new GetFoodTypesQuery())
            };

            if (category != null)
            {
                foodListViewModel.FoodList = await Mediator.Send(new GetFoodListByCategoryQuery
                {
                    Items = foodListViewModel.FoodList,
                    Category = category
                });
            }

            return View(foodListViewModel);
        }

        [HttpGet]
        public IActionResult Delivery()
        {
            return View();
        }

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
