using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Attila.Application.Coordinator.Event.Commands;
using Attila.Application.Coordinator.Event.Queries;
using Attila.Application.Event.Commands;
using Attila.Application.Event.Queries;
using Attila.UI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Attila.UI.Controllers
{
    public class CoordinatorController : Controller
    {
        private readonly IMediator mediator;

        public CoordinatorController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }



        // COORDINATOR COMMANDS START HERE
        [HttpPost]
        public async Task<IActionResult> AddEvent(AddEventVM _eventDetails)
        {

            EventDetailsVM x = new EventDetailsVM
            {
                EventPackageDetailsID = _eventDetails.Selected,
                Code = _eventDetails.Event.Code,
                Description = _eventDetails.Event.Description,
                EventDate = _eventDetails.Event.EventDate,
                EventName = _eventDetails.Event.EventName,
                Location = _eventDetails.Event.Location,
                Remarks = _eventDetails.Event.Remarks,
                Type = _eventDetails.Event.Type,
                EventClientID = _eventDetails.SelectedClient,
                
                
            };

            bool flag = true;
            try
            {
               await mediator.Send(new AddEventCommand{ EventDetails = _eventDetails.Event});
            }catch(Exception)
            {
                flag = false;
            }
            return Json(flag);
        }
        [HttpGet]
        public async Task<IActionResult> AddEvent()
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
            return View(_addEventList);
        }
        

        [HttpPost]
        public async Task<IActionResult> AddEventPackage(EventPackageVM _eventPackage)
        {
            int _duration = _eventPackage.Duration.Hours;
            string _parsedDurationString = _duration.ToString("hh':'mm");
            TimeSpan _fromStringToTimeSpan = TimeSpan.Parse(_parsedDurationString);
            bool flag = true;
            try
            {
                    await mediator.Send(new AddEventPackageCommand
                    {
                        PackageDetails = _eventPackage
                    });

            }
            catch (Exception)
            {
                flag = false;
            }
            return Json(flag);
        }

        [HttpGet]
        public IActionResult AddEventPackage()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddClientDetails(EventClientVM _eventClient)
        {
            bool flag = true;
            try
            {
                await mediator.Send(new AddClientDetailsCommand
                {
                    EventClient = _eventClient
                });
            }
            catch (Exception)
            {
                flag = false;
            }

            return Json(flag);
        }

        [HttpGet]
        public IActionResult AddClientDetails()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddEventPayment(PaymentStatusVM _eventPayment)
        {
            bool flag = true;
            try
            {
                await mediator.Send(new AddPaymentForEventCommand
                {
                    MyEventPaymentStatus = _eventPayment
                });
            }
            catch (Exception)
            {
                flag = false;
            }
               
            return Json(flag);
        }

        [HttpGet]
        public IActionResult AddEventPayment()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> RequestEventRequirements(EventRequirementRequestVM _eventEquipmentRequest)
        {
            bool flag = true;
            try
            {
                if (_eventEquipmentRequest.Quantity != 0)
                {
                    await mediator.Send(new RequestEventRequirementsCommand
                    {
                        EventRequirementRequest = _eventEquipmentRequest
                    });
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception)
            {
                flag = false;
            }
            
            return Json(flag);
        }

        [HttpGet]
        public IActionResult RequestEventRequirements()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateEvent(EventDetailsVM _eventDetails)
        {
            bool flag = true;
            try
            {
                await mediator.Send(new UpdateEventCommand
                {
                    UpdateEvent = _eventDetails
                });
            }
            catch (Exception)
            {
                flag = false;
            }

            return Json(flag);
        }

        [HttpGet]
        public IActionResult UpdateEvent()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateEventPackage(EventPackageVM _eventPackage)
        {
            bool flag = true;
            try
            {
                await mediator.Send(new UpdateEventPackageCommand
                {
                    UpdatePackage = _eventPackage
                });
            }
            catch (Exception)
            {
                flag = false;
            }
            

            return Json(flag);
        }

        [HttpGet]
        public IActionResult UpdateEventPackage()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateClientDetails(EventClientVM _eventClient)
        {
            bool flag = true;
            try
            {
                await mediator.Send(new UpdateClientDetailsCommand
                {
                    ID = _eventClient.ID,
                    Firstname = _eventClient.Firstname,
                    Lastname = _eventClient.Lastname,
                    Email = _eventClient.Email,
                    Address = _eventClient.Address,
                    Contact = _eventClient.Contact

                });
            }catch (Exception)
            {
                flag = false;
            }
            
            return Json(flag);
        }

        [HttpGet]
        public IActionResult UpdateClientDetails()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateEventPaymentStatus(PaymentStatusVM _eventPayment)
        {
            bool flag = true;
            try
            {
                await mediator.Send(new UpdatePaymentStatusCommand
                {
                    UpdatePaymentStatus = _eventPayment
                });
            }
            catch (Exception)
            {
                flag = false;
            }
            

            return Json(flag);
        }

        [HttpGet]
        public IActionResult UpdateEventPaymentStatus()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> DeleteEvent(int _eventId)
        {
            await mediator.Send(new DeleteEventCommand { 
                EventId = _eventId

            });

            return Json(true);
        }

        [HttpGet]
        public IActionResult DeleteEvent()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> DeleteEventPackage(int _packageId)
        {
            await mediator.Send(new DeleteEventPackageCommand
            {
                PackageId = _packageId

            });
            return Json(true);
        }

        [HttpGet]
        public IActionResult DeleteEventPackage()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddAdditionalDurationRequest(AdditionalDurationRequestListVM _additionalDuration)
        {
            bool flag = true;
            try
            {
                await mediator.Send(new AddAdditionalDurationRequestCommand
                {
                    AdditionalPackage = _additionalDuration
                });
            }
            catch (Exception)
            {
                flag = false;
            }
                 
            
            return Json(flag);
        }

        [HttpGet]
        public IActionResult AddAdditionalDurationRequest()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddAdditionalEquipmentRequest(AdditionalEquipmentRequestListVM _additionalEquipment)
        {
            bool flag = true;
            try
            {
                await mediator.Send(new AddAdditionalEquipmentRequestCommand
                {
                    AdditionalEquipment = _additionalEquipment
                });
            }catch (Exception)
            {
                flag = false;
            }
                
            
            return Json(flag);
        }

        [HttpGet]
        public IActionResult AddAdditionalEquipmentRequest()
        {
            return View();
        }

        //COORDINATOR COMMANDS END HERE



        //COORDINATOR QUERIES START HERE
        [HttpGet]
        public IActionResult SearchEventById()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchEventById(int _eventId)
        {
            var _searchResult = await mediator.Send(new SearchEventByIdQuery { 
                EventId = _eventId
            });
            return Json(_searchResult);

        }

        [HttpPost]
        public async Task<IActionResult> SearchEventByKeyword(string _eventKeyword)
        {
            var _searchResult = await mediator.Send(new SearchEventByKeywordQuery { 
                EventKeyword = _eventKeyword
            });
            return Json(_searchResult);
        }

        [HttpPost]
        public async Task<IActionResult> SearchClientById(int _clientId)
        {
            var _searchResult = await mediator.Send(new SearchClientByIdQuery
            {
                ClientId = _clientId
            });
            return Json(_searchResult);
        }

        [HttpPost]
        public async Task<IActionResult> SearchClientByKeyword(string _clientKeyword)
        {
            var _searchResult = await mediator.Send(new SearchClientByKeywordQuery { 
                Keyword = _clientKeyword
            });
            return Json(_searchResult);
        }

        [HttpPost]
        public async Task<IActionResult> GetPaymentStatusById(int _eventID)
        {
            var _searchResult = await mediator.Send(new GetPaymentStatusByEventIDQuery { 
                EventID = _eventID
            });;

            return View(_searchResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetAdditionalDurationRequestList()
        {
            var _searchResult = await mediator.Send(new GetAdditionalDurationRequestListQuery());

            return View(_searchResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetAdditionalEquipmentRequestList()
        {
            var _searchResult = await mediator.Send(new GetAdditionalEquipmentRequestListQuery());

            return View(_searchResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetEventList()
        {
            var _searchResult = await mediator.Send(new GetEventListQuery());

            return View(_searchResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetClientList()
        {
            var _searchResult = await mediator.Send(new GetClientListQuery());

            return View(_searchResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentStatus()
        {
            var _searchResult = await mediator.Send(new GetPaymentStatusQuery());

            return View(_searchResult);
        }

        
        [HttpGet]
        public IActionResult SearchEventByKeyword()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SearchClientById()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SearchClientByKeyword()
        {
            return View();
        }
        //COORDINATOR QUERIES END HERE
    }
}