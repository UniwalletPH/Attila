using Attila.Application.Admin.Event.Queries;
using Attila.Application.Admin.Food.Queries;
using Attila.Application.Admin.Inventory.Queries;
using Attila.Application.Event.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Controllers
{
    public class NotificationController : BaseController
    {
        private readonly IMediator mediator;

        public NotificationController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        public IActionResult Index()
        {
            return View();
        
        }
        [HttpGet]
        public async Task<IActionResult> EventRequestDetails(int id)
        {
            var _details = await mediator.Send(new GetEventDetailQuery { EventID = id });

            return View(_details);
        }

        [HttpGet]
        public async Task<IActionResult> FoodRequestDetails(int id)
        {
            var _details = await mediator.Send(new GetFoodRequestDetailsQuery { RequestID = id });

            return View(_details);
        }

        [HttpGet]
        public async Task<IActionResult> EquipmentRequestDetails(int id)
        {
            var _details = await mediator.Send(new GetEquipmentRequestDetailsQuery { RequestID = id });

            return View(_details);
        }

    }
}
