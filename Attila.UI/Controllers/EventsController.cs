using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Attila.UI.Models;
using MediatR;
using Attila.Application.Admin.Event.Queries;
using Attila.Application.Event.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using Attila.Application.Coordinator.Event.Queries;

namespace Attila.UI.Controllers
{
    public class EventsController : Controller
    {
        private readonly IMediator mediator;

        public EventsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index()
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
        public async Task<IActionResult> BookingForm()
        {
            var _packageNames = await mediator.Send(new GetEventPackageQuery());
            var _clientNames = await mediator.Send(new GetClientListQuery());

            List<SelectListItem> _list = new List<SelectListItem>();

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
                _list.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Firstname + item.Lastname,
                });
            }

            var _addEventList = new AddEventVM();
            _addEventList.PackageList = _list;
            _addEventList.ClientList = _list;
            return View(_addEventList);
        }


        //[HttpPost]
        //public async Task<IActionResult> AddEventPackage(EventPackageVM _eventPackage)
        //{
        //    int _duration = _eventPackage.Duration.Hours;
        //    string _parsedDurationString = _duration.ToString("hh':'mm");
        //    TimeSpan _fromStringToTimeSpan = TimeSpan.Parse(_parsedDurationString);
        //    bool flag = true;
        //    EventPackageVM eventPackageVM = new EventPackageVM
        //    {
        //        Code = _eventPackage.Code,
        //        Description = _eventPackage.Description,
        //        Duration = _fromStringToTimeSpan,
        //        Name = _eventPackage.Name,
        //        NumberOfGuest = _eventPackage.NumberOfGuest,
        //        Rate = _eventPackage.Rate

        //    };

        //    try
        //    {
        //        await mediator.Send(new AddEventPackageCommand
        //        {
        //            PackageDetails = eventPackageVM
        //        });

        //    }
        //    catch (Exception)
        //    {
        //        flag = false;
        //    }
        //    return Json(flag);
        //}

        //[HttpGet]
        //public async Task<IActionResult> Details(int? EventID)
        //{
             
          
        //    if (EventID!= null)
        //    {

        //        var _eventDetails = await mediator.Send(new GetEventDetailQuery { EventID = EventID });

        //    }

        //    var _allEventDetails = new ViewEventVM
        //    {
        //        EventDetails = _eventDetails
        //    };

        //    return View( _allEventDetails);
        //}

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
