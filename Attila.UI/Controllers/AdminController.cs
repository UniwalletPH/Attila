using Attila.Application.Admin.Event.Queries;
using Attila.Application.Admin.Food.Queries;
using Attila.Application.Admin.Inventory.Queries;
using Attila.UI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Attila.UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMediator mediator;

        public AdminController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Event()
        {
            var _pendingEvents = await mediator.Send(new GetAllPendingEventsQuery { });
            var _incomingEvents = await mediator.Send(new GetAllIncomingEventsQuery { });
            var _pastEvents = await mediator.Send(new GetAllPastEventsQuery { });

            var _forEvent = new EventViewVM
            { 
                IncomingEvent = _incomingEvents,
                PastEvent = _pastEvents,
                PendingEvent = _pendingEvents
            };

            return View(_forEvent);

        }



        [HttpGet]
        public async Task<IActionResult> Inventory()
        {
            var _pendingFoodReq = await mediator.Send(new GetPendingFoodRestockRequestQuery { });
            var _pendingEquimentReq = await mediator.Send(new GetPendingEquipmentRestockRequestQuery { });

            var _pendingRequest = new InventoryViewVM
            { 
            PendingFoodRestockRequest = _pendingFoodReq,
            PendingEquipmentRestockRequest = _pendingEquimentReq
            };

            return View(_pendingRequest);
        }

        [HttpGet]
        public IActionResult Notification()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Reports()
        {
            return View();
        }
    }
}