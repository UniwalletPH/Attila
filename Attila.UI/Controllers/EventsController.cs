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
using Attila.Application.Event.Commands;
using Attila.Application.Coordinator.Event.Commands;
using Attila.Application.Admin.Queries;

namespace Attila.UI.Controllers
{
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


            if (User.Identities != null)
            {
                var _searchResult = await mediator.Send(new GetAllEventDetailsListQuery());
                var _pendingEvents = await mediator.Send(new GetAllPendingEventsQuery { });
                var _incomingEvents = await mediator.Send(new GetAllIncomingEventsQuery { });
                var _pastEvents = await mediator.Send(new GetAllPastEventsQuery {  });

                var _forEvent = new EventViewVM
                {
                    IncomingEvent = _incomingEvents,
                    PastEvent = _pastEvents,
                    PendingEvent = _pendingEvents,
                    Events = _searchResult
                };


                return View(_forEvent);
            }
            else
            {
                return Redirect("/Login");
            }


        }



        [HttpGet]
        public async Task<IActionResult> BookingForm()
        {
            if (User.Identities != null)
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
                        Text = item.Firstname + item.Lastname,
                    });
                }

                var _addEventList = new AddEventVM();
                _addEventList.PackageList = _list;
                _addEventList.ClientList = _clientlist;
                return View(_addEventList);
            }
            else
            {
                return Redirect("/Login");
            }

        }


        [HttpPost]
        public async Task<IActionResult> AddEvent(AddEventVM _eventDetails)
        {

            if (User.Identities != null)
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
                    UserID = 1,
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


                try
                {
                    await mediator.Send(new AddEventCommand { EventDetails = x });
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

        [HttpGet]
        public async Task<IActionResult> Details(int EventID) {

            var _eventDetails = await mediator.Send(new GetEventDetailQuery { EventID = EventID });

            ViewEventVM viewEventVM = new ViewEventVM { 
            
            EventDetails = _eventDetails
            
            
            };
            return View(viewEventVM);
 
        }
     

        //[HttpPost]
        //public async Task<IActionResult> Details(int EventID)
        //{

        //    var _eventDetails = await mediator.Send(new GetEventDetailQuery { EventID = EventID });

        //    var _allEventDetails = new ViewEventVM
        //    {
        //        EventDetails = _eventDetails
        //    };

        //    return View(_allEventDetails);

        //}
        [HttpGet]
        public async Task<IActionResult> Packages()
        {
            if (User.Identities!=null)
            {
                var _getPackageList = await mediator.Send(new GetEventPackageListQuery());

                return View(_getPackageList);
            }
            else
            {
                return Redirect("/Login");
            }

            }

            public IActionResult PackageForm()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEventPackage(EventPackageVM _eventPackage)
        {

            if (User.Identities!=null)
            {
                //int _duration = _eventPackage.Duration.Hours;
                //string _parsedDurationString = _duration.ToString("hh':'mm");
                //TimeSpan _fromStringToTimeSpan = TimeSpan.Parse(_parsedDurationString);
                bool flag = true;
                EventPackageVM eventPackageVM = new EventPackageVM
                {
                    Code = _eventPackage.Code,
                    Description = _eventPackage.Description,
                    //Duration = _fromStringToTimeSpan,
                    Name = _eventPackage.Name,
                    RatePerHead = _eventPackage.RatePerHead

                };

                try
                {
                    await mediator.Send(new AddEventPackageCommand
                    {
                        PackageDetails = eventPackageVM
                    });

                }
                catch (Exception)
                {
                    flag = false;
                }
                return Json(flag);

            }else            
            {
                    return Redirect("/Login");
                }
            }


        [HttpGet]
        public async Task<IActionResult> Menu()
        {
            if (User.Identities!=null)
            {
                var eventPackages = await mediator.Send(new GetEventPackageListQuery()); 

            List<SelectListItem> _list = new List<SelectListItem>();

 

            foreach (var item in eventPackages)
            {
                _list.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Name + item.RatePerHead,
                });
            }

            var _packageList = new AddMenuCategoryVM();
           // _packageList.PackageList = _list; 
            return View(_packageList);
            }
            else
            {
                return Redirect("/Login");
            }

        }




        [HttpPost]
        public async Task<IActionResult> AddMenu(AddMenuVM _menuDetails)
        {
            if (User.Identities!=null)
            {
                bool flag = true;
            MenuVM menuDetails = new MenuVM
            {

                Name = _menuDetails.Menu.Name,
                Description = _menuDetails.Menu.Description,
                MenuCategoryID = _menuDetails.Selected

            };

            try
            {
                await mediator.Send(new AddMenuCommand
                {
                    PackageMenu = menuDetails
                });

            }
            catch (Exception)
            {
                flag = false;
            }
            return Json(flag);


        }
            else
            {
                return Redirect("/Login");
    }


}

 
        [HttpPost]
        public async Task<IActionResult> AddMenuCategory(MenuCategoryVM _menu)
        {
            if (User.Identities!=null)
            {
                bool flag = true;
            try
            {
                await mediator.Send(new AddMenuCategoryCommand
                {
                    MenuCategory = _menu
                });
            }
            catch (Exception)
            {
                flag = false;
            }

            return Json(flag);
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
