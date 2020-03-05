using Atilla.Application.Admin.Equipment.Commands;
using Attila.Application.Admin.Commands;
using Attila.Application.Admin.Equipment.Commands;
using Attila.Application.Admin.Event.Queries;
using Attila.Application.Admin.Food.Commands;
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

       [HttpPost]
        public async Task<IActionResult> ViewEvent(int EventID)
        {
            var _eventDetails = await mediator.Send(new GetEventDetailQuery { EventID = EventID});

            var _allEventDetails = new ViewEventVM
            {                 
                EventDetails = _eventDetails
            };

            return PartialView("~/Views/Admin/Partial/_viewEvent.cshtml", _allEventDetails);
        }



        public async Task<IActionResult> ApproveEvent (int eventID)
        {
            var _retVal = await mediator.Send(new ApproveEventRequestCommand { EventID = eventID});

            return Json(_retVal);

        }

        public async Task<IActionResult> DeclineEvent(int eventID)
        {
            var _retVal = await mediator.Send(new DeclineEventRequestCommand { EventID = eventID});

            return Json(_retVal);
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

        public async Task<IActionResult> ApproveFoodRestockRequest(int foodID)
        {
            var _return = await mediator.Send(new ApproveFoodRestockRequestCommand { RequestID = foodID});

            return Json(_return);
        }

        public async Task<IActionResult> DeclineFoodRestockRequest(int foodID)
        {
            var _return = await mediator.Send(new DeclineFoodRestockRequestCommand { RequestID = foodID});

            return Json(_return);
        }

        public async Task<IActionResult> ApproveEquipmentRestockRequest(int equipmentID)
        {

            var _return = await mediator.Send(new ApproveEquipmentRestockRequestCommand { RequestID = equipmentID});

            return Json(_return);
        }
        public async Task<IActionResult> DeclineEquipmentRestockRequest(int equipmentID)
        {

            var _return = await mediator.Send(new DeclineEquipmentRestockRequestCommand {RequestID = equipmentID } );

            return Json(_return);
        }

        public IActionResult Profile()
        {
            return View();
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