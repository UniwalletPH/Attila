using Attila.Application.Admin.Events.Commands;
using Attila.Application.Admin.Events.Queries;
using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Events.Commands;
using Attila.Application.Events.Queries;
using Attila.Application.Notification.Commands;
using Attila.UI.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Attila.UI.Controllers
{
    [Authorize(Roles = "Admin, Coordinator")]
    public class EventsController : BaseController
    {
        private readonly IMediator mediator;
        public static bool _checker;
        public EventsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {

             
                var _searchResult = await mediator.Send(new GetAllEventDetailsListQuery());
                var _pendingEvents = await mediator.Send(new GetAllPendingEventsQuery { });
                var _incomingEvents = await mediator.Send(new GetAllIncomingEventsQuery { });
                var _pastEvents = await mediator.Send(new GetAllPastEventsQuery {  });

                var _forEvent = new EventViewCVM
                {
                    IncomingEvent = _incomingEvents,
                    PastEvent = _pastEvents,
                    PendingEvent = _pendingEvents,
                    Events = _searchResult
                };


                return View(_forEvent);
            


        }



        [HttpGet]
        public async Task<IActionResult> BookingForm()
        {
             
                var _packageNames = await mediator.Send(new GetEventPackageQuery());
                var _clientNames = await mediator.Send(new GetClientListQuery());

                List<SelectListItem> _list = new List<SelectListItem>();

                List<SelectListItem> _clientlist = new List<SelectListItem>();
                foreach (var item in _packageNames)
                {
                    _list.Add(new SelectListItem
                    {
                        Value = item.ID.ToString(),
                        Text = item.Code
                    });

                }

                foreach (var item in _clientNames)
                {
                    _clientlist.Add(new SelectListItem
                    {
                        Value = item.ID.ToString(),
                        Text = item.Name,
                    });
                }

                var _addEventList = new AddEventCVM();
                _addEventList.PackageList = _list;
                _addEventList.ClientList = _clientlist;
                return View(_addEventList);
            
          

        }


        [HttpPost]
        public async Task<IActionResult> AddEvent(AddEventCVM _eventDetails)
        {
             
                EventDetailsVM x = new EventDetailsVM
                {
                    EventName = _eventDetails.Event.EventName,
                    Type = _eventDetails.Event.Type,
                    Description = _eventDetails.Event.Description,
                    EventClientID = _eventDetails.SelectedClient,
                    EventDate = _eventDetails.Event.EventDate,
                    PackageDetailsID = _eventDetails.Selected,
                    Location = _eventDetails.Event.Location,
                    Remarks = _eventDetails.Event.Remarks,
                    UserID = CurrentUser.ID,
                    EventStatus = _eventDetails.Event.EventStatus,
                    EntryTime = _eventDetails.Event.EntryTime,
                    NumberOfGuests = _eventDetails.Event.NumberOfGuests,
                    ProgramStart = _eventDetails.Event.ProgramStart,
                    ServingTime = _eventDetails.Event.ServingTime,
                    LocationType = _eventDetails.Event.LocationType,
                    ServingType = _eventDetails.Event.ServingType,
                    Theme = _eventDetails.Event.Theme,
                    VenueType = _eventDetails.Event.VenueType



                };


                 
            var response = await mediator.Send(new AddEventCommand { EventDetails = x });

            //Send Notif to Admin
            await mediator.Send(new AddNotificationCommand 
            { 
                Message = "New Event Request Received",
                TargetUserID = -1,
                MethodName = "EventRequestDetails",
                RequestID = response 
            });
                   
            return Json(response);
 

        }

        [HttpGet]
        public async Task<IActionResult> Details(int EventID) {

            var _eventDetails = await mediator.Send(new SearchEventByIdQuery { EventId = EventID });



            var _details = new EventDetailsVM
            {
                EventName = _eventDetails.EventName,
                Type = _eventDetails.Type,
                Description = _eventDetails.Description,
                EventClientID = _eventDetails.EventClientID,
                EventDate = _eventDetails.EventDate,
                PackageDetailsID = _eventDetails.PackageDetailsID,                
                Location = _eventDetails.Location,
                Remarks = _eventDetails.Remarks,
                UserID = _eventDetails.UserID,
                EventStatus = _eventDetails.EventStatus,
                EntryTime = _eventDetails.EntryTime,
                NumberOfGuests = _eventDetails.NumberOfGuests,
                ProgramStart = _eventDetails.ProgramStart,
                ServingTime = _eventDetails.ServingTime,
                LocationType = _eventDetails.LocationType,
                ServingType = _eventDetails.ServingType,
                Theme = _eventDetails.Theme,
                VenueType = _eventDetails.VenueType,
                BookingDate = _eventDetails.BookingDate,
                ID = _eventDetails.ID



            };



            var viewEventVM = new ViewEventCVM
            { 
            
            Event = _details
            
            
            };
            return View(viewEventVM);
 
        }
     

        [HttpGet]
        public async Task<IActionResult> Approve(int EventID)
       {
                       
            var response = await mediator.Send(new ApproveEventRequestCommand { EventID = EventID });

            await mediator.Send(new AddNotificationCommand 
            { 
                Message ="Your request has been Approved",
                TargetUserID = response.Coordinator.ID,
                MethodName = "",
                RequestID = response.ID

            });


            return RedirectToAction("Details", new { EventID = EventID });
        }

        public async Task<IActionResult> Decline(int EventID)
        {


            var response = await mediator.Send(new DeclineEventRequestCommand { EventID = EventID });


            return RedirectToAction("Details", new { EventID = EventID });
        }




        [HttpGet]
        public async Task<IActionResult> MenuForm(int EventID)
        {


            var _eventDetails = await mediator.Send(new SearchEventByIdQuery { EventId = EventID });
            var x = new EventDetailsVM
            {
                EventName = _eventDetails.EventName,
                Type = _eventDetails.Type,
                Description = _eventDetails.Description,
                EventClientID = _eventDetails.EventClientID,
                EventDate = _eventDetails.EventDate,
                PackageDetailsID = _eventDetails.PackageDetailsID,
                Location = _eventDetails.Location,
                Remarks = _eventDetails.Remarks,
                UserID = _eventDetails.UserID,
                EventStatus = _eventDetails.EventStatus,
                EntryTime = _eventDetails.EntryTime,
                NumberOfGuests = _eventDetails.NumberOfGuests,
                ProgramStart = _eventDetails.ProgramStart,
                ServingTime = _eventDetails.ServingTime,
                LocationType = _eventDetails.LocationType,
                ServingType = _eventDetails.ServingType,
                Theme = _eventDetails.Theme,
                VenueType = _eventDetails.VenueType,
                BookingDate = _eventDetails.BookingDate,
                ID = _eventDetails.ID



            };

            if (_eventDetails != null)
            {
                var _addmenu = await mediator.Send(new SearchPackageByIdQuery { PackageId = _eventDetails.PackageDetailsID });
                List<SelectListItem> _list = new List<SelectListItem>();




                foreach (var item in _addmenu)
                {
                    _list.Add(new SelectListItem
                    {
                        Value = item.ID.ToString(),
                        Text = item.Menu.Name + " | " + item.Menu.DishCategory
                    });
                }



                AddEventMenuCVM eventDetails = new AddEventMenuCVM
                {
                    Event = x,
                    MenuList = _addmenu,
                    EventID = EventID,
                    Menu = _list


                };


                return View(eventDetails);

            }
            else { return View(); }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
