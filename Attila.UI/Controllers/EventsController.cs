using Attila.Application.Admin.Events.Commands;
using Attila.Application.Admin.Events.Queries;
using Attila.Application.Coordinator.Events.Commands;
using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Events.Commands;
using Attila.Application.Events.Queries;
using Attila.Application.Inventory_Manager.Equipments.Queries;
using Attila.Application.Inventory_Manager.Shared.Queries;
using Attila.Application.Notification.Commands;
using Attila.Application.Users.Queries;
using Attila.UI.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
 

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

        [Authorize(Roles = "InventoryManager,Coordinator,Admin")]
        public async Task<IActionResult> Index()
        {

             
                var _searchResult = await mediator.Send(new GetAllEventDetailsListQuery());
            var _processingEvents = await mediator.Send(new GetAllProcessingEventsQuery { });
                var _pendingEvents = await mediator.Send(new GetAllPendingEventsQuery { });
                var _incomingEvents = await mediator.Send(new GetAllIncomingEventsQuery { });
                var _pastEvents = await mediator.Send(new GetAllPastEventsQuery {  });

                var _forEvent = new EventViewCVM
                {
                    ProcessingEvent = _processingEvents,
                    IncomingEvent = _incomingEvents,
                    PastEvent = _pastEvents,
                    PendingEvent = _pendingEvents,
                    Events = _searchResult
                };


                return View(_forEvent);
            


        }



        [Authorize(Roles = "Admin, Coordinator")]
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
                        Text = item.Name
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

        [Authorize(Roles = "Coordinator")]
        [HttpGet]
        public async Task<IActionResult> AddAdditionalDishRequest()
        {
            var _eventList = await mediator.Send(new GetEventListQuery());
            List<SelectListItem> _events = new List<SelectListItem>();

            foreach (var item in _eventList)
            {
                _events.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.EventName,
                });
            }

            var _addDishRequest = new AdditionalDishCVM();
            _addDishRequest.EventList = _events;
            return View(_addDishRequest);
        }

        [Authorize(Roles = "Coordinator")]

        [HttpPost]
        public async Task<IActionResult> AddAdditionalDishRequest(AdditionalDishCVM _additionalDish)
        {
            AdditionalDishVM _container = new AdditionalDishVM
            {
                EventID = _additionalDish.SelectedEvent,
                Quantity = _additionalDish.AdditionalDish.Quantity,
            };

            var response = await mediator.Send(new AddAdditionalDishRequestCommand{AdditionalDish = _container});

            return Json(response);
        }

        [Authorize(Roles = "Coordinator")]
        [HttpPost]
        public async Task<IActionResult> AddEvent(AddEventCVM _eventDetails)
        {
             
                EventDetailsVM x = new EventDetailsVM
                {
                    EventName = _eventDetails.Event.EventName,
                    Type = _eventDetails.Event.Type,
                    Description = _eventDetails.Event.Description,
                    EventClientID = _eventDetails.Event.EventClientID,
                    EventDate = _eventDetails.Event.EventDate,
                    PackageDetailsID = _eventDetails.Event.PackageDetailsID,
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


                 
            var response = await mediator.Send(new AddEventCommand { EventDetails = x});
             
            await mediator.Send(new AddEventNotificationCommand 
            { 
                Message = "New Event Request Received",
                TargetUserID = -1,
                MethodName = "/Events/Details",
                RequestID = response 
            });
                   

            return Json(response);
 

        }

        [Authorize(Roles = "InventoryManager,Coordinator,Admin")]
        [HttpGet]
        public async Task<IActionResult> Details(int EventID) {

            var _eventDetails = await mediator.Send(new SearchEventByIdQuery { EventId = EventID });
            
            return View (new ViewEventCVM
            { 
                EventDetails = _eventDetails          
            });
 
        }


        [Authorize(Roles = "Admin, Coordinator")]

        [HttpGet]
        public async Task<IActionResult> Update(int EventID)
        {

            var _eventDetails = await mediator.Send(new SearchEventByIdQuery { EventId = EventID });
            var _packageNames = await mediator.Send(new GetEventPackageQuery());
            var _clientNames = await mediator.Send(new GetClientListQuery());

            List<SelectListItem> _list = new List<SelectListItem>();

            List<SelectListItem> _clientlist = new List<SelectListItem>();
            foreach (var item in _packageNames)
            {
                _list.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Name
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


            var _details = new EventDetailsVM
            {
                EventName = _eventDetails.EventName,
                Type = _eventDetails.Type,
                Description = _eventDetails.Description,
                EventClientID = _eventDetails.EventClientID,
                Client = _eventDetails.Client,
                EventDate = _eventDetails.EventDate,
                PackageDetailsID = _eventDetails.PackageDetailsID,
                Package = _eventDetails.Package,
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
 

                List <SelectListItem> OccasionType = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Baptismal", Value = "Baptismal" },
                new SelectListItem { Text = "Birthday", Value = "Birthday" },
                new SelectListItem { Text = "Graduation", Value = "Graduation" },
                new SelectListItem { Text = "Meeting", Value = "Meeting" },
                new SelectListItem { Text = "Wedding", Value = "Wedding" },
                new SelectListItem { Text = "Others", Value = "Others" },

            };
            List <SelectListItem> VenueType = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Yes", Value = "1" },
                new SelectListItem { Text = "No", Value = "2" }, 

            };

            List<SelectListItem> LocationType = new List<SelectListItem>()
            {
                new SelectListItem { Text = "North Area", Value = "1" },
                new SelectListItem { Text = "South Area", Value = "2" }, 

            };

            List<SelectListItem> ServingType = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Manage Buffet", Value = "ManageBuffet" },
                new SelectListItem { Text = "Self Service Buffet", Value = "SelfServiceBuffet" }, 

            };
            @ViewBag.OccasionType = new SelectList(OccasionType, "Value", "Text", _details.Type);
            @ViewBag.VenueType = new SelectList(VenueType, "Value", "Text", _details.VenueType);
            @ViewBag.LocationType = new SelectList(LocationType, "Value", "Text", _details.LocationType);
            @ViewBag.ServingType = new SelectList(ServingType, "Value", "Text", _details.ServingType);

            @ViewBag.Clients = new SelectList(_clientNames, "ID", "Name", _details.Client.ID);

            @ViewBag.Packages = new SelectList(_packageNames, "ID", "Name", _details.Package.ID);
            var _addEventList = new ViewEventCVM();
            _addEventList.PackageList = _list;
            _addEventList.ClientList = _clientlist;
            _addEventList.EventDetails = _details;
            return View(_addEventList);

        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Approve(int EventID)
       {
                       
            var response = await mediator.Send(new ApproveEventRequestCommand { EventID = EventID });

            
            await mediator.Send(new AddEventNotificationCommand 
            { 
                Message ="Your request has been Approved",
                TargetUserID = response.Coordinator.ID,
                MethodName = "/Events/Details",
                RequestID = response.ID
            });
           var inventoryManagerList= await mediator.Send(new GetInventoryManagerListQuery());

            foreach (var item in inventoryManagerList)
            { 
                await mediator.Send(new AddEventNotificationCommand
                {

                    
                    Message = "An event has been Approved",
                    TargetUserID = item.ID,
                    MethodName = "/Events/Details",
                    RequestID = response.ID
                }); ;

            }
     
            return RedirectToAction("Details", new { EventID = EventID });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Decline(int EventID)
        {


            var response = await mediator.Send(new DeclineEventRequestCommand { EventID = EventID });

            await mediator.Send(new AddEventNotificationCommand
            { 
                Message = "Your request has been Declined",
                TargetUserID = response.Coordinator.ID,
                MethodName = "/Events/Details",
                RequestID = response.ID
            });


            return RedirectToAction("Details", new { EventID = EventID });
        }

        [Authorize(Roles = "Coordinator")]

        [HttpPost]
               public async Task<IActionResult> UpdateEvent(ViewEventCVM _eventDetails)

                      {  
                       var response =   await mediator.Send(new UpdateEventCommand
                         {
                             UpdateEvent = _eventDetails.EventDetails
                         });

            return RedirectToAction("Details", new { EventID = _eventDetails.EventDetails.ID });
                     }
    


              [Authorize(Roles = "Admin, Coordinator")]
        [HttpGet]
        public async Task<IActionResult> ChangeEventStatusToCompleted(int EventID)

        {
            var response = await mediator.Send(new ChangeEventStatusToCompletedCommand
            {  
                EventID = EventID
            });

            return RedirectToAction("Details", new { EventID = EventID });
        }
        [Authorize(Roles = "Admin, Coordinator")]
        [HttpGet]
        public async Task<IActionResult> ChangeStatus(int EventID)

        {
            var response = await mediator.Send(new ChangeEventStatusCommand { 
               ID = EventID
            });

            return RedirectToAction("Details", new { EventID = EventID });
        }


        [Authorize(Roles = "Admin, Coordinator")]
        [HttpGet]
        public async Task<IActionResult> MenuForm(int EventID)
        {


            var _eventDetails = await mediator.Send(new SearchEventByIdQuery { EventId = EventID });
           
            if (_eventDetails != null)
            {
                var _addmenu = await mediator.Send(new SearchPackageByIdQuery { PackageId = _eventDetails.PackageDetailsID });
                var _dishCategories = await mediator.Send(new GetAllDishCategoryQuery{});

                List<SelectListItem> _list = new List<SelectListItem>();

               


                var _dishGroupbyCategory = _addmenu.GroupBy(_addmenu => _addmenu.Menu.DishCategory);


                AddEventMenuCVM eventDetails = new AddEventMenuCVM
                {
                    Event = _eventDetails,
                    MenuList = _addmenu,
                    EventID = EventID,
                    Menu = _list,
                    Groupings = _dishGroupbyCategory                    
                };


                return View(eventDetails);

            }
            else { return View(); }

        }

        [Authorize(Roles = "Admin, Coordinator")]
        [HttpPost]
        public async Task<IActionResult> AddMenu(AddEventMenuCVM addEvent)
        {
            var _evntMenu = new List<EventMenuVM>();


            foreach (var item in addEvent.SelectedMenu)
            {
                var _menu = new EventMenuVM
                { 
                    EventDetailsID = addEvent.EventID,
                    DishID = item
                };

                _evntMenu.Add(_menu);
            }


            var _rVal = await mediator.Send(new AddEventMenuCommand { EventMenu = _evntMenu});


            return Json(_rVal);
        }



        [Authorize(Roles = "Coordinator")]

        [HttpGet]
        public async Task<IActionResult> Additional(int EventID)
        {

            var _equipmentRequest = await mediator.Send(new FindAdditionalEquipmentRequestByEventIDQuery { EventID = EventID});
            var _dishRequest = await mediator.Send(new FindAdditionalDishRequestByEventIDQuery { EventID = EventID});


            if (_equipmentRequest != null && _dishRequest != null)
            {
                var _equipmentRequested = await mediator.Send(new GetAdditionalEquipmentCollectionQuery 
                {
                    EventAdditionalEquipmentRequestID = _equipmentRequest.RequestID 
                });

                var _dishRequested = await mediator.Send(new GetAdditionalDishCollectionQuery 
                { 
                    EventAdditionalDishRequestID = _dishRequest.RequestID 
                });

                var _equipments = await mediator.Send(new GetAllEquipmentsQuery { });

                var _selectListEquipment = new List<SelectListItem>();

                foreach (var item in _equipments)
                {
                    _selectListEquipment.Add(new SelectListItem
                    {
                        Text = item.Name +"|"+ item.UnitType,
                        Value = item.ID.ToString()
                    });
                }

                var _dishes = await mediator.Send(new GetAllDishQuery { });

                var _selectListDishes = new List<SelectListItem>();

                foreach (var item in _dishes)
                {
                    _selectListDishes.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.ID.ToString()
                    });
                }


                var _additionalModel = new AdditionalsCVM
                {
                    EventID = EventID,
                    EquipmentRequested = _equipmentRequested,
                    DishRequested = _dishRequested,
                    DishList = _selectListDishes,
                    EquipmentList = _selectListEquipment
                };


                return View(_additionalModel);

            }
            else if (_equipmentRequest != null && _dishRequest == null)
            {
                var _equipmentRequested = await mediator.Send(new GetAdditionalEquipmentCollectionQuery 
                { 
                    EventAdditionalEquipmentRequestID = _equipmentRequest.RequestID 
                });

                var _equipments = await mediator.Send(new GetAllEquipmentsQuery { });

                var _selectListEquipment = new List<SelectListItem>();

                foreach (var item in _equipments)
                {
                    _selectListEquipment.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.ID.ToString()
                    });
                }

                var _dishes = await mediator.Send(new GetAllDishQuery { });

                var _selectListDishes = new List<SelectListItem>();

                foreach (var item in _dishes)
                {
                    _selectListDishes.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.ID.ToString()
                    });
                }

                var _additionalModel = new AdditionalsCVM
                {
                    EventID = EventID,
                    EquipmentList = _selectListEquipment,
                    EquipmentRequested = _equipmentRequested,
                    DishList = _selectListDishes

                };


                return View(_additionalModel);

            }
            else if (_equipmentRequest == null && _dishRequest != null)
            {
                var _dishRequested = await mediator.Send(new GetAdditionalDishCollectionQuery 
                { 
                    EventAdditionalDishRequestID = _dishRequest.RequestID 
                });

                var _equipments = await mediator.Send(new GetAllEquipmentsQuery { });

                var _selectListEquipment = new List<SelectListItem>();

                foreach (var item in _equipments)
                {
                    _selectListEquipment.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.ID.ToString()
                    });
                }

                var _dishes = await mediator.Send(new GetAllDishQuery { });

                var _selectListDishes = new List<SelectListItem>();

                foreach (var item in _dishes)
                {
                    _selectListDishes.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.ID.ToString()
                    });
                }

                var _additionalModel = new AdditionalsCVM
                {
                    EventID = EventID,
                    DishRequested = _dishRequested,
                    DishList = _selectListDishes,
                    EquipmentList = _selectListEquipment
                };

                return View(_additionalModel);

            }

            else
            {
                var _equipments = await mediator.Send(new GetAllEquipmentsQuery { });

                var _selectListEquipment = new List<SelectListItem>();

                foreach (var item in _equipments)
                {
                    _selectListEquipment.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.ID.ToString()
                    });
                }

                var _dishes = await mediator.Send(new GetAllDishQuery { });

                var _selectListDishes = new List<SelectListItem>();

                foreach (var item in _dishes)
                {
                    _selectListDishes.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.ID.ToString()
                    });
                }


                var _additionalModel = new AdditionalsCVM
                {
                    EventID = EventID,                
                    DishList = _selectListDishes,
                    EquipmentList = _selectListEquipment
                };


                return View(_additionalModel);


            }

   
        }

        [Authorize(Roles = "Coordinator")]
        [HttpPost]
        public async Task<IActionResult> AddAdditionalEquipment(AdditionalsCVM additionals)
        {

            var _equipmentRequest = await mediator.Send(new FindAdditionalEquipmentRequestByEventIDQuery 
            { 
                EventID = additionals.EventID 
            });

            if (_equipmentRequest != null)
            {
                var _additionalEquipmentRequest = new AdditionalEquipmentRequestListVM
                {
                    EquipmentDetailsID = additionals.AdditionalEquipmentRequest.EquipmentDetailsID,
                    RequestID = _equipmentRequest.RequestID,
                    Quantity = additionals.AdditionalEquipmentRequest.Quantity
                };

                var _rV = await mediator.Send(new AddAdditionalEquipmentRequestCommand 
                { 
                    AdditionalEquipment = _additionalEquipmentRequest 
                });

                return Json(_rV);

            }
            else
            { 
                var _requestID = await mediator.Send(new CreateAdditionalEquipmentRequestCommand 
                { 
                    EventID = additionals.EventID
                });

                var _additionalEquipmentRequest = new AdditionalEquipmentRequestListVM
                {
                    EquipmentDetailsID = additionals.AdditionalEquipmentRequest.EquipmentDetailsID,
                    RequestID = _requestID,
                    Quantity = additionals.AdditionalEquipmentRequest.Quantity
                };

                var _rVal = await mediator.Send(new AddAdditionalEquipmentRequestCommand 
                { 
                    AdditionalEquipment = _additionalEquipmentRequest 
                });


                return Json(_rVal);

            }
          
        }

        [Authorize(Roles = "Admin, Coordinator")]
        [HttpPost]
        public async Task<IActionResult> AddAdditionalDish(AdditionalsCVM additionals)
        {
            var _dishRequest = await mediator.Send(new FindAdditionalDishRequestByEventIDQuery 
            { 
                EventID = additionals.EventID 
            });

            if (_dishRequest != null)
            {
                var _additionalDishRequest = new EventDishRequestVM
                {
                    DishID = additionals.AdditionalDishRequest.DishID,
                    RequestID = _dishRequest.RequestID,
                    Quantity = additionals.AdditionalDishRequest.Quantity
                };

                var _rVal = await mediator.Send(new AddAdditionalDishRequestCollectionCommand 
                { 
                    Dish = _additionalDishRequest 
                });
            }
            else
            {
                var _requestID = await mediator.Send(new CreateAdditionalDishRequestCommand 
                { 
                    EventID = additionals.EventID
                });

                var _additionalDishRequest = new EventDishRequestVM
                {
                    DishID = additionals.AdditionalDishRequest.DishID,
                    RequestID = _requestID,
                    Quantity = additionals.AdditionalDishRequest.Quantity
                };

                var _rVal = await mediator.Send(new AddAdditionalDishRequestCollectionCommand 
                { 
                    Dish = _additionalDishRequest 
                });
            }

            return Json(true);
        }

        [Authorize(Roles = "Admin, Coordinator")]
        [HttpPost]
        public async Task<IActionResult> AddAdditionalDuration(AdditionalsCVM additionals)
        {
            var _add = new AdditionalDurationRequestVM
            { 
                Duration = additionals.AdditionalDurationRequest.Duration,
                EventDetailsID = additionals.EventID,

            };

            var _rVal = await mediator.Send(new AddAdditionalDurationRequestCommand { AdditionalPackage = _add });

            return Json(true);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
