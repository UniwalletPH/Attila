﻿using Attila.Application.Admin.Equipments.Queries;
using Attila.Application.Admin.Events.Queries;
using Attila.Application.Admin.Foods.Queries;
using Attila.Application.Notification.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Attila.UI.Controllers
{

    [Authorize(Roles = "Admin,Coordinator,InventoryManager, ")]
    public class NotificationController : BaseController
    {
        private readonly IMediator mediator;

        public NotificationController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        public async Task<IActionResult> Index()
        {
            var _notifList = await mediator.Send(new GetNotificationQuery { TargetID = CurrentUser.ID});

            return View(_notifList);
        
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
