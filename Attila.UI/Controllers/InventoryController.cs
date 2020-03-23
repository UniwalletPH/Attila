using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; 
using Attila.UI.Models;
using MediatR;
using Attila.Application.Food.Queries;
using Attila.Application.Inventory_Manager.Food.Queries; 
using Attila.Application.Food.Commands;
using Microsoft.AspNetCore.Mvc.Rendering; 
using Attila.Application.Inventory_Manager.Shared.Queries;
using Microsoft.AspNetCore.Http; 

namespace Attila.UI.Controllers
{
    public class InventoryController : Controller
    {
        public static bool _checker;

        private readonly IMediator mediator;

        public InventoryController(IMediator mediator) { 
            this.mediator = mediator; 
           }
            
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (User.Identities!=null) {
                try
                        {
                        var getDetails = await mediator.Send(new GetInventoryDetailsQuery());
                        return View(getDetails);
                         }
                  catch (Exception)
                         {       
                      throw;
                      }
                }
            else
                 {
                return Redirect("/Login");
                }
        }

 
        public IActionResult AddFood()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddFoodDetails(FoodsDetailsVM foodDetails)
        {
            if (User.Identities!=null)
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
            else
            {
                return Redirect("/Login");
            }
        }
        public IActionResult AddEquipment()
        {
            if (User.Identities!=null)
            {

                return View();
            }
            else
            {
                return Redirect("/Login");
            }
        }
        public IActionResult UpdateStocks()
        {

            if (User.Identities!=null)
            {

                return View();
            }
            else
            {
                return Redirect("/Login");
            }
        }

        [HttpGet]
        public async Task<IActionResult> RequestFoodRestock()
        {
            if (User.Identities!=null)
            {
                var getFoodDetails = await mediator.Send(new GetFoodDetailsQuery());
            List<SelectListItem> _list = new List<SelectListItem>();

            foreach (var item in getFoodDetails)
            {
                _list.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Code + " | " + item.Name + " | " + item.Description
                });
            }

            FoodRestockRequestVM foodDetailsListVM = new FoodRestockRequestVM
            {
                FoodDetailsList = _list
            };

            return View(foodDetailsListVM);
        }
            else
                 {
                return Redirect("/Login");
    }
}


        [HttpPost]
        public async Task<IActionResult> RequestFoodRestock(FoodsRestockRequestVM foodRestockRequest)
        {
            if (User.Identities!=null)
            {
                FoodsRestockRequestVM _foodRequestDetails = new FoodsRestockRequestVM
                {
                    FoodDetailsID = foodRestockRequest.FoodDetailsID,

                    Quantity = foodRestockRequest.Quantity,
                    Status = Domain.Enums.Status.Pending,
                    UserID = 1
                };
                                  
               try
                {
                    await mediator.Send(new RequestFoodRestockCommand
                    {
                        MyFoodRestockRequestVM = _foodRequestDetails
                    });
                    _checker = true;
                }
                catch (Exception)
                {
                    _checker = false;
                }

                return Json(_checker);
            }
            else
            {
                return Redirect("/Login");
            }
            } 
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
