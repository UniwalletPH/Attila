using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Attila.UI.Models;
using MediatR;
using Attila.Application.Food.Queries;
using Attila.Application.Inventory_Manager.Food.Queries;
using Attila.Application.Food.Commands;

namespace Attila.UI.Controllers
{
    public class InventoryController : Controller
    {
        public static bool _checker;

        private readonly IMediator mediator;

        public InventoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var _getFoodDetails = await mediator.Send(new GetFoodDetailsQuery());
                return View(_getFoodDetails.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

 
        public IActionResult AddFood()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddFoodDetails(FoodsDetailsVM foodDetails)
        {
            try
            {
                await mediator.Send(new AddFoodDetailsCommand
                {
                    MyFoodDetailsVM = foodDetails
                });
                _checker = true;
            }
            catch (Exception)
            {
                _checker = false;
            }

            return Json(_checker);
        }
        public IActionResult AddEquipment()
        {
            return View();
        }
        public IActionResult UpdateStocks()
        {
            return View();
        }
        public IActionResult RequestRestock()
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
