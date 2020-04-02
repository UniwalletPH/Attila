using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Attila.UI.Models;
using MediatR;
using Attila.Application.Events.Queries;
using Attila.Application.Admin.Foods.Queries;
using Attila.Application.Admin.Equipments.Queries;
using Attila.Application.Inventory_Manager.Shared.Queries;
using Attila.Application.Admin.Events.Queries;

namespace Attila.UI.Controllers
{
    public class ReportsController : BaseController
    {

        private readonly IMediator mediator;

        public ReportsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
         
        public async Task<IActionResult> Index()
        {
            var _pendingFoodReq = await mediator.Send(new GetPendingFoodRestockRequestQuery { });
            var _pendingEquimentReq = await mediator.Send(new GetPendingEquipmentRestockRequestQuery { });
            var _pendingEvents = await mediator.Send(new GetAllPendingEventsQuery { });
            var _getInventoryDeliveryList = await mediator.Send(new GetInventoryDeliveryQuery());


            var results = new ReportCVM { 
            
            Delivery = _getInventoryDeliveryList,
            Events = _pendingEvents,
            FoodRequest = _pendingFoodReq,
            EquipmentRequest  = _pendingEquimentReq

            };

            return View(results);
          
 
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
