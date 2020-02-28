using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Attila.Application.Coordinator.Event.Commands;
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
        #region HTTP POSTs

        [HttpPost]
        public async Task<IActionResult> AddEvent(EventDetailsVM _eventDetails)
        {
            bool flag = true;
            try
            {
                
                    await mediator.Send(new AddEventCommand
                    {
                        Address = _eventDetails.Address,
                        BookingDate = DateTime.Now,
                        Code = _eventDetails.Code,
                        Description = _eventDetails.Description,
                        EventDate = _eventDetails.EventDate,
                        EventName = _eventDetails.EventName,
                        Location = _eventDetails.Location,
                        Type = _eventDetails.Type,
                        Remarks = _eventDetails.Remarks,
                        UserID = _eventDetails.UserID,
                        EventClientID = _eventDetails.EventClientID,
                        EventPackageDetailsID = _eventDetails.EventPackageDetailsID
                    });
            }catch(Exception)
            {
                flag = false;
            }
            return Json(flag);
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
                        Code = _eventPackage.Code,
                        Description = _eventPackage.Description,
                        Duration = _fromStringToTimeSpan,
                        NumberOfGuest = _eventPackage.NumberOfGuest,
                        Rate = _eventPackage.Rate

                    });

            }
            catch (Exception)
            {
                flag = false;
            }
            return Json(flag);
        }

        [HttpPost]
        public async Task<IActionResult> AddClientDetails(EventClientVM _eventClient)
        {
            bool flag = true;
            try
            {
                await mediator.Send(new AddClientDetailsCommand
                {
                    Address = _eventClient.Address,
                    Contact = _eventClient.Contact,
                    Email = _eventClient.Email,
                    Lastname = _eventClient.Lastname,
                    Firstname = _eventClient.Firstname
                });
            }
            catch (Exception)
            {
                flag = false;
            }

            return Json(flag);
        }

        [HttpPost]
        public async Task<IActionResult> AddEventPayment(EventPaymentVM _eventPayment)
        {
            bool flag = true;
            try
            {
                await mediator.Send(new AddPaymentForEventCommand
                {
                    Amount = _eventPayment.Amount,
                    DateOfPayment = _eventPayment.DateOfPayment,
                    EventDetailsID = _eventPayment.EventDetailsID,
                    ReferenceNumber = _eventPayment.ReferenceNumber,
                    Remarks = _eventPayment.Remarks

                });
            }
            catch (Exception)
            {
                flag = false;
            }
               
            return Json(flag);
        }

        [HttpPost]
        public async Task<IActionResult> RequestEventRequirements(EventEquipmentRequestVM _eventEquipmentRequest)
        {
            bool flag = true;
            try
            {
                if (_eventEquipmentRequest.Quantity != 0)
                {
                    await mediator.Send(new RequestEventRequirementsCommand
                    {
                        EquipmentDetailsID = _eventEquipmentRequest.EquipmentDetailsID,
                        EventDetailsID = _eventEquipmentRequest.EventDetailsID,
                        Quantity = _eventEquipmentRequest.Quantity,

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

        [HttpPost]
        public async Task<IActionResult> UpdateEvent(EventDetailsVM _eventDetails)
        {
            bool flag = true;
            try
            {
                await mediator.Send(new UpdateEventCommand
                {
                    ID = _eventDetails.ID,
                    Address = _eventDetails.Address,
                    Description = _eventDetails.Description,
                    EventDate = _eventDetails.EventDate,
                    EventName = _eventDetails.EventName,
                    Location = _eventDetails.Location,
                    Type = _eventDetails.Type,
                    Remarks = _eventDetails.Remarks

                });
            }
            catch (Exception)
            {
                flag = false;
            }

            return Json(flag);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEventPackage(EventPackageVM _eventPackage)
        {
            bool flag = true;
            try
            {
                await mediator.Send(new UpdateEventPackageCommand
                {
                    ID = _eventPackage.ID,
                    Code = _eventPackage.Code,
                    Description = _eventPackage.Description,
                    Duration = _eventPackage.Duration,
                    NumberOfGuest = _eventPackage.NumberOfGuest,
                    Rate = _eventPackage.Rate
                });
            }
            catch (Exception)
            {
                flag = false;
            }
            

            return Json(flag);
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

        [HttpPost]
        public async Task<IActionResult> UpdateEventPaymentStatus(EventPaymentVM _eventPayment)
        {
            bool flag = true;
            try
            {
                await mediator.Send(new UpdatePaymentStatusCommand
                {
                    ID = _eventPayment.ID,
                    Amount = _eventPayment.Amount,
                    DateOfPayment = _eventPayment.DateOfPayment,
                    ReferenceNumber = _eventPayment.ReferenceNumber,
                    Remarks = _eventPayment.Remarks
                });
            }
            catch (Exception)
            {
                flag = false;
            }
            

            return Json(flag);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEvent(int _eventId)
        {
            await mediator.Send(new DeleteEventCommand { 
                EventId = _eventId

            });

            return Json(true);
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

        [HttpPost]
        public async Task<IActionResult> AddAdditionalDurationRequest(PackageAdditionalDurationRequestVM _additionalDuration)
        {
            bool flag = true;
            try
            {
                await mediator.Send(new AddAdditionalDurationRequestCommand
                {
                    Duration = _additionalDuration.Duration,
                    Rate = _additionalDuration.Rate,
                    EventDetailsID = _additionalDuration.EventDetailsID
                });
            }
            catch (Exception)
            {
                flag = false;
            }
                 
            
            return Json(flag);
        }

        [HttpPost]
        public async Task<IActionResult> AddAdditionalEquipmentRequest(PackageAdditionalEquipmentRequestVM _additionalEquipment)
        {
            bool flag = true;
            try
            {
                await mediator.Send(new AddAdditionalEquipmentRequestCommand
                {
                    EventDetailsID = _additionalEquipment.EventDetailsID,
                    EquipmentDetailsID = _additionalEquipment.EquipmentDetailsID,
                    Rate = _additionalEquipment.Rate,
                    Quantity = _additionalEquipment.Quantity,
                });
            }catch (Exception)
            {
                flag = false;
            }
                
            
            return Json(flag);
        }
        #endregion
        #region HTTP GETs
        [HttpGet]
        public async Task<IActionResult> AddEvent()
        {
            var _packageNames = await mediator.Send(new GetEventPackageQuery());

            List<SelectListItem> _list = new List<SelectListItem>();

            foreach (var item in _packageNames)
            {
                _list.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Code

                });
            }

            var x = new EventDetailsVM();
            x.PackageList = _list;
            return View(x);
        }

        [HttpGet]
        public IActionResult AddEventPackage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddClientDetails()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddEventPayment()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RequestEventRequirements()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateEvent()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateEventPackage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateClientDetails()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateEventPaymentStatus()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeleteEvent()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeleteEventPackage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddAdditionalDurationRequest()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddAdditionalEquipmentRequest()
        {
            return View();
        }

        #endregion
        //COORDINATOR COMMANDS END HERE







        //COORDINATOR QUERIES START HERE
        #region HTTP POSTs

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

        #endregion
        #region HTTP GETs
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

        #endregion
        //COORDINATOR QUERIES END HERE
    }
}